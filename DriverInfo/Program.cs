using System;
using System.IO;

namespace io
{
    class Program
    {
        static void Main(string[] args)
        {
            long sizeByte;
            long sizeKByte;
            long sizeMByte;
            long sizeGByte;
            string size;

            long totalFreeSizeByte;
            long totalFreeSizeKByte;
            long totalFreeSizeMByte;
            long totalFreeSizeGByte;
            string totalFreeSize;

            long totalSizeByte;
            long totalSizeKByte;
            long totalSizeMByte;
            long totalSizeGByte;
            string totalSize;

            DriveInfo[] iform = DriveInfo.GetDrives();
            foreach (var item in iform)
            {
                //подсчет свободного пространства
                sizeByte = item.AvailableFreeSpace;
                sizeKByte = (sizeByte - item.AvailableFreeSpace / 1000000 * 1000000) / 1000;
                sizeMByte = (sizeByte - item.AvailableFreeSpace / 1000000000 * 1000000000) / 1000000;
                sizeGByte = item.AvailableFreeSpace / 1000000000;

                totalFreeSizeByte = item.TotalFreeSpace;
                totalFreeSizeKByte = (totalFreeSizeByte - item.TotalFreeSpace / 1000000 * 1000000) / 1000;
                totalFreeSizeMByte = (totalFreeSizeByte - item.TotalFreeSpace / 1000000000 * 1000000000) / 1000000;
                totalFreeSizeGByte = item.TotalFreeSpace / 1000000000;

                totalSizeByte = item.TotalSize;
                totalSizeKByte = (totalSizeByte - item.TotalSize / 1000000 * 1000000) / 1000;
                totalSizeMByte = (totalSizeByte - item.TotalSize / 1000000000 * 1000000000) / 1000000;
                totalSizeGByte = item.TotalSize / 1000000000;

                size = String.Format("{0:###### Гб }", sizeGByte) + String.Format("{0:###### Мб}", sizeMByte);
                totalFreeSize = String.Format("{0:###### Гб }", totalFreeSizeGByte) + String.Format("{0:###### Мб}", totalFreeSizeMByte);
                totalSize = String.Format("{0:###### Гб }", totalSizeGByte) + String.Format("{0:###### Мб}", totalSizeMByte);
                Console.WriteLine($"Информация по диску - {item}\n\n\t" +
                                  $"Доступное свободное место на диске: {size}\n\t" +
                                  $"Формат файловой системы: {item.DriveFormat}\n\t" +
                                  $"Тип диска: {item.DriveType}\n\t" +
                                  $"Готов ли диск: {item.IsReady}\n\t" +
                                  $"Название диска: {item.Name}\n\t" +
                                  $"Общий объем свободного места на диске: {totalFreeSize:f2}\n\t" +
                                  $"Общий размер диска: {totalSize:f2}\n\t" +
                                  $"Метка тома: {item.VolumeLabel}\n\t");
            }
            Console.ReadKey();
        }
    }
}
