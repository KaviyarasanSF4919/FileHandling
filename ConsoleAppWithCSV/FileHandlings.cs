using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Diagnostics.Contracts;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.Json;
using System.Threading.Tasks;

namespace ConsoleAppWithCSV
{
    public class FileHandlings<DataType>
    {
        private bool _exist;
        private string _filePath;
        public bool CanReadWrite { get { return _exist; } }
        public string FIlePath { get { return _filePath; } }
        public FileType _fileType = FileType.TXT;
        public FileHandlings(FileType fileType)
        {
            _fileType = fileType;
            string filePathDirectory = @"DataBase";
            if (!Directory.Exists(filePathDirectory))
            {
                Directory.CreateDirectory(filePathDirectory);
            }
            string filePath = filePathDirectory + "/" + typeof(DataType).Name + ToFileType(_fileType);
            if (!File.Exists(filePath))
            {
                _exist = true;
                File.Create(filePath).Close();
            }
            else if (File.ReadAllLines(filePath).Length == 0)
            {
                _exist = true;
            }
            _filePath = filePath;
        }
        public void Read(out CustomList<DataType> customList)
        {
            customList = new CustomList<DataType>();
            switch (_fileType)
            {
                case FileType.TXT:
                    {
                        customList = ReadFromTXT();
                        break;
                    }
                case FileType.CSV:
                    {
                        customList = ReadFromCSV();
                        break;
                    }
                case FileType.JSON:
                    {
                        customList = ReadFromJSON();
                        break;
                    }
                default:
                    {
                        Console.WriteLine($"wrong file Format");
                        break;
                    }
            }
        }
        public void Write(CustomList<DataType> list)
        {
            switch (_fileType)
            {
                case FileType.TXT:
                    {
                        WriteToTXT(list);
                        break;
                    }
                case FileType.CSV:
                    {
                        WriteToCSV(list);
                        break;
                    }
                case FileType.JSON:
                    {
                        WriteToJSON(list);
                        break;
                    }
            }

        }
        public string ToFileType(FileType type)
        {
            switch (type)
            {
                case FileType.Default:
                case FileType.TXT:
                    {
                        return ".txt";
                    }
                case FileType.CSV:
                    {
                        return ".csv";
                    }
                case FileType.JSON:
                    {
                        return ".json";
                    }
                default:
                    {
                        return "";
                    }
            }
        }
        public string FileSeparator(FileType type)
        {
            switch (type)
            {
                case FileType.Default:
                case FileType.TXT:
                    {
                        return " ";
                    }
                case FileType.CSV:
                    {
                        return ",";
                    }
                case FileType.JSON:
                    {
                        return ":";
                    }
                default:
                    {
                        return "";
                    }
            }
        }
        public CustomList<DataType> ReadFromTXT()
        {
            CustomList<DataType> list = new CustomList<DataType>();
            string separator = FileSeparator(_fileType);
            string[] rows = File.ReadAllLines(_filePath);
            PropertyInfo[] properties = typeof(DataType).GetProperties();
            foreach (string row in rows)
            {
                string[] values = row.Split(separator);
                DataType data = Activator.CreateInstance<DataType>();
                for (int i = 0; i < properties.Length; i++)
                {
                    if (properties[i].PropertyType == typeof(DataType))
                    {
                        properties[i].SetValue(data, DateTime.ParseExact(values[i], "dd/MM/yyyy", null));
                    }
                    else if (properties[i].PropertyType == typeof(int))
                    {
                        properties[i].SetValue(data, int.Parse(values[i]));
                    }
                    else if (properties[i].PropertyType == typeof(double))
                    {
                        properties[i].SetValue(data, double.Parse(values[i]));
                    }
                    else if (properties[i].PropertyType == typeof(bool))
                    {
                        properties[i].SetValue(data, bool.Parse(values[i]));
                    }
                    else if (properties[i].PropertyType == typeof(string))
                    {
                        properties[i].SetValue(data, values[i]);
                    }
                    else if (properties[i].PropertyType.IsEnum)
                    {
                        properties[i].SetValue(data, Enum.Parse(properties[i].PropertyType, values[i], true));
                    }
                }
                list.Add(data);

            }
            return list;
        }
        public CustomList<DataType> ReadFromCSV()
        {
            CustomList<DataType> list = new CustomList<DataType>();
            string separator = FileSeparator(_fileType);
            string[] rows = File.ReadAllLines(_filePath);
            PropertyInfo[] properties = typeof(DataType).GetProperties();
            foreach (string row in rows)
            {
                string[] values = row.Split(separator);
                DataType data = Activator.CreateInstance<DataType>();
                for (int i = 0; i < properties.Length; i++)
                {
                    if (properties[i].PropertyType == typeof(DataType))
                    {
                        properties[i].SetValue(data, DateTime.ParseExact(values[i], "dd/MM/yyyy", null));
                    }
                    else if (properties[i].PropertyType == typeof(int))
                    {
                        properties[i].SetValue(data, int.Parse(values[i]));
                    }
                    else if (properties[i].PropertyType == typeof(double))
                    {
                        properties[i].SetValue(data, double.Parse(values[i]));
                    }
                    else if (properties[i].PropertyType == typeof(bool))
                    {
                        properties[i].SetValue(data, bool.Parse(values[i]));
                    }
                    else if (properties[i].PropertyType == typeof(string))
                    {
                        properties[i].SetValue(data, values[i]);
                    }
                    else if (properties[i].PropertyType.IsEnum)
                    {
                        properties[i].SetValue(data, Enum.Parse(properties[i].PropertyType, values[i], true));
                    }
                }
                list.Add(data);
            }
            return list;
        }
        public CustomList<DataType> ReadFromJSON()
        {
            var option = new JsonSerializerOptions
            {
                WriteIndented = true
            };
            CustomList<DataType> list = JsonSerializer.Deserialize<CustomList<DataType>>(File.ReadAllText(_filePath), option);
            return list;
        }
        public void WriteToTXT(CustomList<DataType> list)
        {
            string separator = FileSeparator(_fileType);
            StreamWriter streamWriter = new StreamWriter(_filePath);
            PropertyInfo[] properties = typeof(DataType).GetProperties();
            foreach (DataType data in list)
            {
                string line = "";
                for (int i = 0; i < properties.Length; i++)
                {
                    if (properties[i].PropertyType == typeof(DateTime))
                    {
                        line += ((DateTime)properties[i].GetValue(data)).ToString("dd/MM/yyyy");
                    }
                    else if (properties[i].PropertyType == typeof(int))
                    {
                        line += properties[i].GetValue(data).ToString();
                    }
                    else if (properties[i].PropertyType == typeof(double))
                    {
                        line += properties[i].GetValue(data).ToString();
                    }
                    else if (properties[i].PropertyType == typeof(bool))
                    {
                        line += properties[i].GetValue(data).ToString();
                    }
                    else if (properties[i].PropertyType == typeof(string))
                    {
                        line += properties[i].GetValue(data).ToString();
                    }
                    else if (properties[i].PropertyType.IsEnum)
                    {
                        line += properties[i].GetValue(data).ToString();
                    }
                    line += separator;
                }
                streamWriter.WriteLine(line);
            }
            streamWriter.Close();
        }
        public void WriteToCSV(CustomList<DataType> list)
        {
            string separator = FileSeparator(_fileType);
            StreamWriter streamWriter = new StreamWriter(_filePath);
            PropertyInfo[] properties = typeof(DataType).GetProperties();
            foreach (DataType data in list)
            {
                string line = "";
                for (int i = 0; i < properties.Length; i++)
                {
                    if (properties[i].PropertyType == typeof(DateTime))
                    {
                        line += ((DateTime)properties[i].GetValue(data)).ToString("dd/MM/yyyy");
                    }
                    else if (properties[i].PropertyType == typeof(int))
                    {
                        line += properties[i].GetValue(data).ToString();
                    }
                    else if (properties[i].PropertyType == typeof(double))
                    {
                        line += properties[i].GetValue(data).ToString();
                    }
                    else if (properties[i].PropertyType == typeof(bool))
                    {
                        line += properties[i].GetValue(data).ToString();
                    }
                    else if (properties[i].PropertyType == typeof(string))
                    {
                        line += properties[i].GetValue(data).ToString();
                    }
                    else if (properties[i].PropertyType.IsEnum)
                    {
                        line += properties[i].GetValue(data).ToString();
                    }
                    line += separator;
                }
                streamWriter.WriteLine(line);
            }
            streamWriter.Close();
        }
        public void WriteToJSON(CustomList<DataType> list)
        {
            StreamWriter sw = new StreamWriter(_filePath);
            var option = new JsonSerializerOptions
            {
                WriteIndented = true
            };
            string jsonData = JsonSerializer.Serialize(list, option);
            sw.WriteLine(jsonData);
            sw.Close();
        }

    }
}
