Imports System.Runtime.CompilerServices
Imports System.Security.Cryptography
Imports System.Text

Public Module StringBuilderExtensions

    ''' <summary>
    ''' Generates a random sequence of letters and numbers
    ''' </summary>
    ''' <param name="builder">The builder that is being extended</param>
    ''' <param name="len">The number of random characters to append to the string</param>
    ''' <returns>The string builder</returns>
    <Extension()> _
    Public Function AppendRandomString(ByVal builder As StringBuilder, ByVal len As Integer) As StringBuilder
        Dim chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890".ToCharArray()
        Dim data(len - 1) As Byte

        Dim crypto = New RNGCryptoServiceProvider()
        crypto.GetNonZeroBytes(data)

        For Each b In data
            builder.Append(chars(b Mod (chars.Length - 1)))
        Next

        Return builder
    End Function

End Module