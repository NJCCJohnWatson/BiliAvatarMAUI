using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiliAvatarMAUI
{
    /// <summary>
    /// Async is important on GUI programs
    /// </summary>
    public class FileIO
    {
        public async Task<bool> WriteBinaryToFile(string filepath, byte[] bytes)
        {
            using (FileStream fs = File.Open(filepath, FileMode.OpenOrCreate))
            {
                fs.Seek(0, SeekOrigin.End);
                await fs.WriteAsync(bytes);
                return true;
            }
        }
        public async Task<string> TakePath()
        {
            if (MediaPicker.Default.IsCaptureSupported)
            {
                FileResult photo = await MediaPicker.Default.PickPhotoAsync();

                if (photo != null)
                {
                    // save the file into local storage
                    return photo.FullPath;
                }
                else
                {
                    return "";
                }
            }
            else
            {
                return "";
            }
        }        
    }
    public static class Verify
    {
        public static string FilterillegalCharacters(string filname)
        {
            char[] illegalchars = Path.GetInvalidFileNameChars();
            var filenameChars = filname.ToCharArray();
            foreach (var illegalchar in illegalchars)
            {
                if (filname.Contains(illegalchar))
                {
                    filname.Remove(illegalchar);
                }
            }
            return filname;
        }
    }
    public static class Verify
    {
        public static string FilterillegalCharacters(string filname)
        {
            char[] illegalchars = Path.GetInvalidFileNameChars();
            var filenameChars = filname.ToCharArray();
            foreach (var illegalchar in illegalchars)
            {
                if (filname.Contains(illegalchar))
                {
                    filname.Remove(illegalchar);
                }
            }
            return ReplaceIlleageChacters(filname);
        }
        public static string ReplaceIlleageChacters(string name)
        {
            if (name.Contains('?'))
            {
                name = name.Replace("?", "？");
            }
            return name;
        }
    }
}
