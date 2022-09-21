Imports System.Windows.Forms

Public Class SQLGeneralrProcesser
    ''' <summary>
    ''' DataSetにSELECT結果をﾊﾞｲﾝﾄﾞして戻す
    ''' </summary>
    ''' <param name="Sql"></param>
    ''' <remarks></remarks>
    Public Shared Function SetDataSet(ByVal Sql As String) As DataSet
        Dim Rds As DataSet = Nothing
        Try
            Using Cn As New SqlClient.SqlConnection(_Ini.CnString)
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
            Using Cn As New SqlClient.SqlConnection(_Ini.CnString)
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
    ''' 重複ﾁｪｯｸ
    ''' </summary>
    ''' <param name="Sql"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function DupChk(ByVal Sql As String) As Boolean

        Dim Count As Integer
        Dim blnRtn As Boolean = False

        Try
            Using Cn As New SqlClient.SqlConnection(_Ini.CnString)
                Cn.Open()
                Using Cmd As New SqlClient.SqlCommand(Sql, Cn)
                    Count = CInt(Cmd.ExecuteScalar)
                End Using
            End Using

            If Count > 0 Then
                MessageBox.Show("該当するデータが既に存在します。", "通知",
                                            MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Else
                blnRtn = True
            End If

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

        Try
            Using Cn As New SqlClient.SqlConnection(_Ini.CnString)
                Cn.Open()
                Using Cmd As New SqlClient.SqlCommand(Sql, Cn)
                    Count = CInt(Cmd.ExecuteScalar)
                End Using
            End Using

            If Count > 0 Then
                blnRtn = True
            Else
                MessageBox.Show("該当するデータが存在しませんでした。", "通知",
                                            MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If

        Catch ex As Exception
            Throw ex

        End Try

        Return blnRtn

    End Function
End Class
