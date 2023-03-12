Public Class Form1

    Dim createdText As String
    Dim originalText As String
    Dim tanukiNumber As Integer = 3
    Dim favoriteWord As String = "た"

    '文字が入る間隔を調整する処理
    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles TextBox3.TextChanged
        If Me.TextBox3.Text = String.Empty Then
            tanukiNumber = 3
        End If

        If Int32.TryParse(Me.TextBox3.Text, tanukiNumber) Then
            tanukiNumber = CInt(Me.TextBox3.Text)
        Else
            tanukiNumber = 3
        End If

        Me.Label1.Text = $"もとの言葉（{tanukiNumber}文字以上）"


    End Sub

    '暗号の文字変更についての処理
    Private Sub TextBox4_TextChanged(sender As Object, e As EventArgs) Handles TextBox4.TextChanged
        If Me.TextBox3.Text = String.Empty Then
            favoriteWord = "た"
        End If

        favoriteWord = Me.TextBox4.Text

        Me.Button1.Text = $"{favoriteWord}ぬき言葉にできるか判定"
        Me.Label2.Text = $"{favoriteWord}ぬき言葉"

    End Sub

    '生成	文章をたぬき言葉に変換する
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        originalText = Trim(Me.TextBox1.Text)
        originalText = originalText.Replace(Environment.NewLine, "")
        Dim len As Integer = originalText.Length
        If len < tanukiNumber Then
            MessageBox.Show($"もとの言葉の文字数が足りないため、{favoriteWord}ぬき言葉にできません。",
                            "情報",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information)
            Return
        End If

        If originalText.Contains(favoriteWord) Then
            MessageBox.Show($"もとの言葉に「{favoriteWord}」が含まれているため生成できません。	",
                            "情報",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information
                            )
            Return
        End If


        For i As Integer = 0 To originalText.Length - 1
            createdText += originalText(i)

            If ((i + 1) Mod tanukiNumber) = 0 And Not i = 0 Then
                createdText += favoriteWord
            End If

        Next

        Me.TextBox2.Text = createdText

        originalText = ""

        TextBox1.Clear()



    End Sub


    '解読	たぬき言葉をもとの言葉に変換する
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim changedText As String = Me.TextBox2.Text
        If changedText = "" Then
            MessageBox.Show($"{favoriteWord}ぬき言葉が入力されていません。",
                            "情報",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information)
        End If

        Dim revertText As String = ""
        For i As Integer = 0 To changedText.Length - 1
            If Not changedText(i) = favoriteWord Then
                revertText += changedText(i)
            End If
        Next

        Me.TextBox1.Text = revertText

        createdText = String.Empty

    End Sub


    '判定	文章をたぬき言葉に変換できるか判定する
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        originalText = Trim(Me.TextBox1.Text)
        originalText = originalText.Replace(Environment.NewLine, "")
        Dim len As Integer = originalText.Length
        If len < tanukiNumber Then
            MessageBox.Show($"もとの言葉の文字数が足りないため、{favoriteWord}ぬき言葉にできません。",
                            "情報",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information
                            )
            Return
        End If

        If originalText.Contains(favoriteWord) Then
            MessageBox.Show($"もとの言葉に「{favoriteWord}」が含まれているため生成できません。	",
                            "情報",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information
                            )
        Else
            MessageBox.Show($"{favoriteWord}ぬき言葉にできます。",
                        "情報",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                        )

        End If

    End Sub


End Class
