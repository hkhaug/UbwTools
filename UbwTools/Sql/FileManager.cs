using System;
using System.IO;
using System.Windows.Forms;
using UbwTools.Common;
using UbwTools.Common.Gui;

namespace UbwTools.Sql
{
    public class FileManager
    {
        private static FileManager _instance;
        public static FileManager Instance
        {
            get { return _instance ?? (_instance = new FileManager()); }
        }

        private FileManager()
        {
        }

        private string _currentStatementFile;
        private string _currentStatementPath;

        private string GetDefaultFileFolder()
        {
            string folder = string.IsNullOrWhiteSpace(_currentStatementPath)
                ? Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
                : _currentStatementPath;
            if (!folder.EndsWith(Path.DirectorySeparatorChar.ToString()))
            {
                folder += Path.DirectorySeparatorChar;
            }
            return folder;
        }

        public void FileOpen()
        {
            string folder = GetDefaultFileFolder();
            OpenFileDialog dialog = new OpenFileDialog
            {
                AddExtension = true,
                CheckFileExists = true,
                CheckPathExists = true,
                DefaultExt = "sql",
                Filter = "SQL og ASQL filer (*.sql;*.asq)|*.sql;*.asq|SQL filer (*.sql)|*.sql|ASQL filer (*.asq)|*.asq|Alle filer (*.*)|*.*",
                FilterIndex = 1,
                InitialDirectory = folder,
                Multiselect = false,
                RestoreDirectory = true,
                Title = "Åpne fil med SQL-uttrykk"
            };
            if (DialogResult.OK == dialog.ShowDialog(SqlCommon.SqlForm))
            {
                try
                {
                    using (new WaitingCursor())
                    {
                        Stream stream = dialog.OpenFile();
                        StreamReader reader = new StreamReader(stream);
                        string text = reader.ReadToEnd();
                        reader.Close();
                        SqlCommon.Statements.SetEntireSqlStatement(text);
                        _currentStatementFile = Path.GetFileName(dialog.FileName);
                        _currentStatementPath = Path.GetFullPath(dialog.FileName);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(SqlCommon.SqlForm,
                        string.Format("Klarer ikke å lese filen \"{0}\":\r\n\r\n{1}", dialog.FileName, ex.Message),
                        Global.FullTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public void FileSave()
        {
            if (string.IsNullOrWhiteSpace(_currentStatementFile))
            {
                FileSaveAs();
            }
            else
            {
                string filePath = _currentStatementPath + _currentStatementFile;
                try
                {
                    using (new WaitingCursor())
                    {
                        Stream stream = new FileStream(filePath, FileMode.Create, FileAccess.Write);
                        StreamWriter writer = new StreamWriter(stream);
                        writer.Write(SqlCommon.SqlForm.textBoxSql.Text.Trim());
                        writer.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(SqlCommon.SqlForm,
                        string.Format("Klarer ikke å skrive til filen \"{0}\":\r\n\r\n{1}", filePath, ex.Message),
                        Global.FullTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public void FileSaveAs()
        {
            string folder = GetDefaultFileFolder();
            SaveFileDialog dialog = new SaveFileDialog
            {
                AddExtension = true,
                CheckPathExists = true,
                DefaultExt = "sql",
                Filter = "SQL og ASQL files (*.sql;*.asq)|*.sql;*.asq|SQL filer (*.sql)|*.sql|ASQL filer (*.asq)|*.asq|Alle filer (*.*)|*.*",
                FilterIndex = 2,
                InitialDirectory = folder,
                RestoreDirectory = true,
                Title = "Lagre SQL-uttrykk til fil"
            };
            if (DialogResult.OK == dialog.ShowDialog(SqlCommon.SqlForm))
            {
                try
                {
                    using (new WaitingCursor())
                    {
                        Stream stream = new FileStream(dialog.FileName, FileMode.Create, FileAccess.Write);
                        StreamWriter writer = new StreamWriter(stream);
                        writer.Write(SqlCommon.SqlForm.textBoxSql.Text.Trim());
                        writer.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(SqlCommon.SqlForm,
                        string.Format("Klarer ikke å skrive til filen \"{0}\":\r\n\r\n{1}", dialog.FileName, ex.Message),
                        Global.FullTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
