namespace SecEncrypt;

using System.IO;
using System.Text;

public class RepoFileStream
{
    private readonly FileInfo _filePath;

    public RepoFileStream(FileInfo filePath)
    {
        _filePath = filePath;
    }

    public RepoFileStream(string filePath)
    {
        _filePath = new FileInfo(filePath);
    }

    public void Write(string content)
    {
        byte[] encrypted = AESStream.Encrypt(content);
        File.WriteAllBytes(_filePath.FullName, encrypted);
    }

    public string Read()
    {
        if (!_filePath.Exists) return string.Empty;
        byte[] encrypted = File.ReadAllBytes(_filePath.FullName);
        return AESStream.Decrypt(encrypted);
    }
}
