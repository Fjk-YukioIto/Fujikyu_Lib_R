Option Strict On
Option Explicit On

Imports System.Net
Imports System.Xml
Imports System.Xml.Serialization
Imports System.Text.RegularExpressions
Imports System.Windows.Forms

Public Class AddressSearch

#Region "ﾒﾝﾊﾞ"

    ''' <summary>
    ''' 検索先指定　
    ''' </summary>
    Public Enum BASE
        ''' <summary>
        ''' 郵便番号検索API
        ''' </summary>
        API = 0
        ''' <summary>
        ''' KEN_ALL.CSV参照
        ''' </summary>
        CSV = 1
    End Enum

    ''' <summary>
    ''' Resultリストの位置指定用
    ''' </summary>
    Public Enum LstPos
        Result = 0
        Message = 1
        Ken = 2
        Shi = 3
        Cho = 4
        Ken_Kana = 5
        Shi_Kana = 6
        Cho_Kana = 7
    End Enum

    ''' <summary>
    ''' KEN_ALL.CSVの項目位置
    ''' </summary>
    Public Enum CsvPos
        Dantai = 0
        OldPost = 1
        NewPost = 2
        Ken_Kana = 3
        Shi_Kana = 4
        Cho_Kana = 5
        Ken = 6
        Shi = 7
        Cho = 8
        DobCho = 9
        Ban = 10
        Tyo = 11
        Multi = 12
        Upd = 13
        Why = 14
    End Enum

    ''' <summary>
    ''' サーバーから返却された XML をデシリアライズするローカルクラス
    ''' </summary>
    Public Class ZIP_result

        Private _value As Object

        <XmlElement("ADDRESS_value", GetType(Object))>
        Public Property ADDRESS_value() As Object
            Get
                Return _value
            End Get
            Set(value As Object)
                _value = value
            End Set
        End Property

        Public ReadOnly Property State() As String
            Get
                Return GetValue("state")
            End Get
        End Property

        Public ReadOnly Property City() As String
            Get
                Return GetValue("city")
            End Get
        End Property

        Public ReadOnly Property Address() As String
            Get
                Return GetValue("address")
            End Get
        End Property

        Public ReadOnly Property State_Kana() As String
            Get
                Return GetValue("state_kana")
            End Get
        End Property

        Public ReadOnly Property City_Kana() As String
            Get
                Return GetValue("city_kana")
            End Get
        End Property

        Public ReadOnly Property Address_Kana() As String
            Get
                Return GetValue("address_kana")
            End Get
        End Property

        Private Function GetValue(name As String) As String
            Dim ret As String = String.Empty
            If (_value Is Nothing) Then Return ret

            Dim nodes = CType(_value, XmlNode())
            For Each node In nodes
                If (node.Attributes(name) IsNot Nothing) Then
                    ret = node.Attributes(name).Value.Replace("none", "")
                    Exit For
                End If
            Next
            Return ret
        End Function
    End Class

    ''' <summary>
    '''住所検索処理の結果表示用 
    ''' </summary>
    Public Structure SrtResult
        Shared Accept As String = "0"
        Shared Failed As String = "1"

        ''' <summary>
        ''' 正常終了
        ''' </summary>
        Shared I100 As String = "正常終了"
        ''' <summary>
        ''' Error
        ''' </summary>
        Shared E100 As String = "Error"
        ''' <summary>
        ''' 郵便番号が入力されていません
        ''' </summary>
        Shared E101 As String = "郵便番号が入力されていません"
        ''' <summary>
        ''' 郵便番号が正しくありません
        ''' </summary>
        Shared E102 As String = "郵便番号が正しくありません"
        ''' <summary>
        ''' 住所が見つかりませんでした
        ''' </summary>
        Shared E103 As String = "住所が見つかりませんでした"
        ''' <summary>
        ''' CSVファイルが見つかりませんでした
        ''' </summary>
        Shared E104 As String = "CSVファイルが見つかりませんでした"
        ''' <summary>
        ''' ネットワーク接続されているか確認してください
        ''' </summary>
        Shared E105 As String = "ネットワーク接続されているか確認してください"
        ''' <summary>
        ''' APIサーバーへの接続ができませんでした
        ''' </summary>
        Shared E106 As String = "APIサーバーへの接続ができませんでした"


    End Structure

#End Region

#Region "ﾒｿｯﾄﾞ"

    ''' <summary>
    ''' 引数の文字列から住所を検索し文字列リストで返します
    ''' </summary>
    ''' <param name="zipcode">郵便番号(ﾊｲﾌﾝ無し)</param>
    ''' <param name="From">検索先の指定：0→API　1→CSV</param>
    ''' <returns>検索結果</returns>
    Public Shared Function GetAddress(ByVal zipcode As String, ByVal Optional From As Integer = 0) As List(Of String)

        Dim ret As New List(Of String)

        ' 郵便番号の入力ﾁｪｯｸ
        If (String.IsNullOrEmpty(zipcode)) Then
            Return MakeError(SrtResult.E101)
        End If

        ' 郵便番号か検証（ハイフンは含めない）
        If (Not Regex.IsMatch(zipcode, "^[0-9]{7}$")) Then
            Return MakeError(SrtResult.E102)
        End If
        Try
            Select Case From
                Case BASE.API
#Region "GetAddresAPI"

                    ' [郵便番号検索API] http://zip.cgis.biz/ を利用させて頂いてます。
                    Dim url = "http://zip.cgis.biz/xml/zip.php?zn=" + zipcode
                    Dim webreq = System.Net.WebRequest.Create(New System.Uri(url))

                    If Not System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable() Then
                        Return MakeError(SrtResult.E105)
                    ElseIf Not IsInternetConnected(url) Then
                        Return MakeError(SrtResult.E106)
                    End If

                    ' サーバーからの応答を受信するための WebResponse を取得
                    Using webres = webreq.GetResponse(), st = webres.GetResponseStream()
                        ' デシリアライズ
                        Dim reader As New XmlTextReader(st)
                        Dim serializer As New System.Xml.Serialization.XmlSerializer(
                        GetType(ZIP_result),
                        New System.Xml.Serialization.XmlRootAttribute("ZIP_result")
                    )
                        Dim result = CType(serializer.Deserialize(reader), ZIP_result)

                        '検索結果をリストにバインディング
                        If (result IsNot Nothing) And result.State <> "" Then
                            Dim ress As String() = {SrtResult.Accept, SrtResult.E100,
                                                            result.State, result.City, result.Address,
                                                           StrConv(result.State_Kana, VbStrConv.Narrow),
                                                           StrConv(result.City_Kana, VbStrConv.Narrow),
                                                           StrConv(result.Address_Kana, VbStrConv.Narrow)}
                            ret.AddRange(ress)

                        Else
                            ret = MakeError(SrtResult.E103)
                        End If
                    End Using
#End Region

                Case BASE.CSV
#Region "GetAddresCSV"
                    Dim filead As String = "\\172.16.1.72\全社共有\郵便番号データ\KEN_ALL.CSV"
                    'ファイルの存在ﾁｪｯｸ
                    If Not System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable() Then
                        ret = MakeError(SrtResult.E105)
                    ElseIf Not System.IO.File.Exists(filead) Then
                        ret = MakeError(SrtResult.E104)
                    End If

                    Dim strow As String()
                    'ファイル読込
                    Using adr As New Microsoft.VisualBasic.FileIO.TextFieldParser(filead, System.Text.Encoding.GetEncoding("Shift_JIS"))
                        With adr
                            .TextFieldType = Microsoft.VisualBasic.FileIO.FieldType.Delimited
                            .HasFieldsEnclosedInQuotes = True
                            .TrimWhiteSpace = True
                            .SetDelimiters(",")
                        End With

                        '1行ずつ読み込み郵便番号を線形探索
                        strow = adr.ReadFields()
                        Do While strow(CsvPos.NewPost).Contains(zipcode) = False AndAlso Not adr.EndOfData
                            strow = adr.ReadFields()
                        Loop
                    End Using

                    '郵便番号が見つかっていればリストにバインディング
                    If strow(CsvPos.NewPost).ToString = zipcode Then
                        Dim ress As String() = {SrtResult.Accept, SrtResult.E100,
                                                        strow(CsvPos.Ken), strow(CsvPos.Shi), strow(CsvPos.Cho),
                                                        strow(CsvPos.Ken_Kana), strow(CsvPos.Shi_Kana), strow(CsvPos.Cho_Kana)}

                        ret.AddRange(ress)
                    Else
                        ret = MakeError(SrtResult.E103)
                    End If
#End Region

                Case Else
                    ret = MakeError(SrtResult.E103)
            End Select

        Catch e As Exception
            ret = MakeError(SrtResult.E105)
        End Try

        Return ret

    End Function

    ''' <summary>
    ''' ｲﾝﾀｰﾈｯﾄに接続されているか
    ''' </summary>
    ''' <returns>接続されているときはtrue</returns>
    Public Shared Function IsInternetConnected(ByVal host As String) As Boolean
        'インターネットに接続されているか確認する
        'Dim host As String = "http://www.yahoo.com"

        Dim webreq As System.Net.HttpWebRequest = Nothing
        Dim webres As System.Net.HttpWebResponse = Nothing
        Try
            'HttpWebRequestの作成
            webreq = CType(System.Net.WebRequest.Create(host),
                System.Net.HttpWebRequest)
            'メソッドをHEADにする
            webreq.Method = "HEAD"
            '受信する
            webres = CType(webreq.GetResponse(), System.Net.HttpWebResponse)
            '応答ステータスコードを表示
            Select Case webres.StatusCode
                Case HttpStatusCode.Accepted
                    Return True
                Case HttpStatusCode.OK
                    Return True
                Case Else
                    Return False
            End Select
        Catch ex As Exception
            Throw ex
        Finally
            If Not (webres Is Nothing) Then
                webres.Close()
            End If
        End Try
    End Function

    ''' <summary>
    ''' ｴﾗｰ用List作成
    ''' </summary>
    ''' <param name="Ename"></param>
    ''' <returns></returns>
    Public Shared Function MakeError(ByVal Ename As String) As List(Of String)
        Dim Elist As New List(Of String) From {
            SrtResult.Failed,
            Ename
        }
        For i = 0 To 5
            Elist.Add(SrtResult.E100)
        Next

        Return Elist
    End Function

#End Region

End Class

