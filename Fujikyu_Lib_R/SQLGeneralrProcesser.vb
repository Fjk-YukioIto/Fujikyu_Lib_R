Imports System.Windows.Forms

Public Class SQLGeneralrProcesser

#Region "ﾒﾝﾊﾞ"
    ''' <summary>
    ''' SQL接続情報
    ''' </summary>
    Private Shared CnString As String = String.Empty

#End Region

#Region "構造体"

    ''' <summary>
    ''' SQLｺﾝﾊﾞｰｼﾞｮﾝ用
    ''' </summary>
    Public Enum CnvMode
        _WhereStr = 0
        _WhereNum = 1
        _Values = 2
        _Set = 3
        _InsNumber = 4
        _UpdNumber = 5
        _InsNull = 6
        _UpdNull = 7
    End Enum

#End Region

#Region "ﾒｿｯﾄﾞ"

    ''' <summary>
    ''' 接続情報を設定
    ''' </summary>
    ''' <param name="Ini"></param>
    Public Shared Sub InitConnection(ByVal Ini As String)
        CnString = Ini
    End Sub

    ''' <summary>
    ''' DataSetにSELECT結果をﾊﾞｲﾝﾄﾞして戻す
    ''' </summary>
    ''' <param name="Sql"></param>
    ''' <remarks></remarks>
    Public Shared Function SetDataSet(ByVal Sql As String) As DataSet
        Dim Rds As DataSet = Nothing
        Try
            Using Cn As New SqlClient.SqlConnection(CnString)
                Using Adp As New SqlClient.SqlDataAdapter(Sql, Cn)
                    Using ds As New DataSet
                        Adp.Fill(ds)
                        Rds = ds
                    End Using
                End Using
            End Using

        Catch ex As Exception
            Throw ex

        End Try

        Return Rds

    End Function

    ''' <summary>
    ''' 更新系のSQLを実行
    ''' </summary>
    ''' <param name="Sql"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function ExecuteSql(ByVal Sql As String) As Boolean

        Dim Trn As SqlClient.SqlTransaction
        Dim blnRtn As Boolean = False

        Try
            Using Cn As New SqlClient.SqlConnection(CnString)
                Cn.Open()
                Trn = Cn.BeginTransaction
                Using Cmd As New SqlClient.SqlCommand(Sql, Cn, Trn)
                    Try
                        Cmd.ExecuteNonQuery()
                        Cmd.Transaction.Commit()
                    Catch ex As Exception
                        Cmd.Transaction.Rollback()
                        Throw ex
                    End Try
                End Using
            End Using

            blnRtn = True

        Catch ex As Exception
            Throw ex

        End Try

        Return blnRtn

    End Function


    ''' <summary>
    ''' 存在ﾁｪｯｸ
    ''' </summary>
    ''' <param name="Sql"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function ExistChk(ByVal Sql As String) As Boolean

        Dim Count As Integer
        Dim blnRtn As Boolean = False
        'sqlの実行結果を読み込み
        Try
            Using Cn As New SqlClient.SqlConnection(CnString)
                Cn.Open()
                Using Cmd As New SqlClient.SqlCommand(Sql, Cn)
                    Count = CInt(Cmd.ExecuteScalar)
                End Using
            End Using

            If Count > 0 Then
                blnRtn = True
            End If

        Catch ex As Exception
            Throw ex
        End Try

        Return blnRtn

    End Function

    ''' <summary>
    ''' SQL文字列NULL用ｺﾝﾊﾞｰｼﾞｮﾝ
    ''' </summary>
    ''' <param name="param"></param>
    ''' <param name="mode"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function CnvSqlString(ByVal param As String, ByVal mode As Integer) As String

        Select Case mode
            Case CnvMode._WhereStr
                'WHERE句(文字列用)
                If param = String.Empty Then
                    Return " = ''"
                Else
                    Return " = '" & param & "'"
                End If

            Case CnvMode._WhereNum
                'WHERE句(数値用)
                Return " = " & param

            Case CnvMode._Values
                'INSERT句(文字列用)
                If param = String.Empty Then
                    Return " ''"
                Else
                    Return "'" & param & "'"
                End If

            Case CnvMode._Set
                'UPDATE句(文字列用)
                If param = String.Empty Then
                    Return " = ''"
                Else
                    Return " = '" & param & "'"
                End If

            Case CnvMode._InsNumber
                'INSERT句(数値用)
                Return " " & param

            Case CnvMode._UpdNumber
                'UPDATE句(数値用)
                If param = String.Empty Then
                    Return " = 0"
                Else
                    Return " = " & param
                End If

            Case CnvMode._InsNull
                Return " NULL"

            Case CnvMode._UpdNull
                Return " = NULL"

            Case Else
                Return ""

        End Select

    End Function




#End Region

End Class
