using System;
using System.IO.Compression;
using System.IO;

namespace Utilidades
{
    public static class ComprimirYExtraer
    {

        public static void Compresion(FileInfo fileToCompress, string direccion)
        {
            using (FileStream originalFileStream = fileToCompress.OpenRead())
            {
                if ((File.GetAttributes(fileToCompress.FullName) & FileAttributes.Hidden) != FileAttributes.Hidden & fileToCompress.Extension != ".gz")
                {
                    //using (FileStream compressFileStream = File.Create(direccion + @"\" + fileToCompress.Name.Substring(0, fileToCompress.Name.Length - 4) + ".rar"))
                    using (FileStream compressFileStream = File.Create(direccion + @"\" + fileToCompress.Name + ".rar"))
                    {
                        using (GZipStream compressionStream = new GZipStream(compressFileStream, CompressionMode.Compress))
                        {
                            originalFileStream.CopyTo(compressionStream);
                        }
                    }
                    //FileInfo info = new FileInfo(directoryPath + @"\" + archivo.Name +".gz");
                }
            }

        }

        public static void Descomprimir(FileInfo archivo, string direccion)
        {
            using (FileStream originalFileStream = archivo.OpenRead())
            {
                string nombreArchivo = archivo.Name;
                string nuevoArchivo = direccion + @"\" + nombreArchivo;//.Remove(nombreArchivo.Length - archivo.Extension.Length);

                using (FileStream archivoDescomprimido = File.Create(nuevoArchivo)) {
                    using (GZipStream comStream = new GZipStream(originalFileStream, CompressionMode.Decompress)) {
                        comStream.CopyTo(archivoDescomprimido);
                    }
                }
            }
        }
        public static string Descomprimir(FileInfo fileToDecompress)
        {
            string res = "";
            using (FileStream originalFileStream = fileToDecompress.OpenRead())
            {
                string currentFileName = fileToDecompress.FullName;
                string newFileName = currentFileName.Remove(currentFileName.Length - fileToDecompress.Extension.Length);
                res = newFileName;
                using (FileStream decompressedFileStream = File.Create(newFileName))
                {
                    using (GZipStream decompressionStream = new GZipStream(originalFileStream, CompressionMode.Decompress))
                    {
                        decompressionStream.CopyTo(decompressedFileStream);
                        Console.WriteLine($"Decompressed: {fileToDecompress.Name}");
                    }
                }
            }
            return res;
        }
    }
}
