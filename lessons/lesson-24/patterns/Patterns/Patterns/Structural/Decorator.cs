using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace TradingApp.Patterns
{
    public class Program
    {
        public void Main()
        {
            // Stream

            // Динамическое расширение

            // FileCompressEncryptStream : FileCompress : FileStream

            // CompressStream : FileStream
            // {
            //     Read() => Compress(base.Read())
            // }

            // CompressStream : Stream
            // {
            //     Stream inner;
            //
            //     Read() => Compress(inner.Read())
            // }

            var stream = new FileStream();

            // file -> compress stream -> encrypt

            // file -> encrypt -> compress stream

            // memory -> encrypt -> compress stream

            var zipStream = new GZipStream(stream);
            var encStream = new CryptoStream(zipStream);
        }

    }

    public abstract class Matrioshka
    {
        protected abstract void Play();
    }

    public class KhohlomaMatrioshka : Matrioshka
    {
        public KhohlomaMatrioshka(Matrioshka matrioshka)
        {
        }

        protected override void Play()
        {
            // использовать вложенный объект
        }
    }

    public class ClassicMatrioshka : Matrioshka
    {
        public ClassicMatrioshka(Matrioshka matrioshka)
        {

        }

        protected override void Play()
        {
            // использовать вложенный объект
        }
    }
}
