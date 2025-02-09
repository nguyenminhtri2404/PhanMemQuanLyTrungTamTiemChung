using Microsoft.Office.Interop.Word;
using System.Collections.Generic;
using System.Reflection;
namespace Utilities
{
    public class WordExport
    {
        private Application _app;
        private Document _doc;
        private object _pathFile;
        private object missing = Missing.Value; // Thêm biến missing


        public void Close()
        {
            _doc.Close();

            // Đóng ứng dụng Word
            _app.Quit();
        }

        public void SaveAs(string outputPath)
        {
            _doc.SaveAs2(outputPath); // Lưu tài liệu với tên mới
            _doc.Close();
            _app.Quit();
        }

        public void WordUltil(string vPath, bool vCreateApp)
        {
            _pathFile = vPath;
            _app = new Application();
            _app.Visible = vCreateApp;
            object ob = System.Reflection.Missing.Value;
            _doc = _app.Documents.Add(ref _pathFile, ref ob, ref ob, ref ob);
        }

        public void WriteFields(Dictionary<string, string> vValues)
        {
            foreach (Field field in _doc.Fields)
            {
                string fieldName = field.Code.Text.Substring(11, field.Code.Text.IndexOf("\\") - 12).Trim();
                if (vValues.ContainsKey(fieldName))
                {
                    field.Select();
                    _app.Selection.TypeText(vValues[fieldName]);
                }
            }
        }

        public void WriteTable(System.Data.DataTable dataTable, int tableIndex)
        {
            // Lấy bảng trong Word
            Table tbl = _doc.Tables[tableIndex];

            // Kiểm tra số cột trong bảng Word có đủ hay không
            int numberOfColumns = tbl.Columns.Count;

            // Kiểm tra nếu số cột trong bảng Word chưa đủ 6, cần phải tạo thêm cột
            while (numberOfColumns < 6)
            {
                tbl.Columns.Add();
                numberOfColumns++;
            }

            // Duyệt qua các dòng của DataTable
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                // Thêm dòng mới vào bảng Word nếu cần thiết
                if (i + 2 > tbl.Rows.Count) // +2 vì dòng đầu là tiêu đề
                {
                    tbl.Rows.Add();
                }

                // Duyệt qua các cột của DataTable và điền vào bảng
                for (int j = 0; j < 6; j++)  // Đảm bảo có 6 cột
                {
                    // Thêm dữ liệu vào ô tương ứng trong bảng
                    tbl.Cell(i + 2, j + 1).Range.Text = dataTable.Rows[i][j].ToString();
                }
            }
        }

        public void WriteTablePay(System.Data.DataTable dataTable, int tableIndex)
        {
            // Lấy bảng trong Word
            Table tbl = _doc.Tables[tableIndex];

            // Kiểm tra số cột trong bảng Word có đủ hay không
            int numberOfColumns = tbl.Columns.Count;

            // Kiểm tra nếu số cột trong bảng Word chưa đủ 6, cần phải tạo thêm cột
            while (numberOfColumns < 5)
            {
                tbl.Columns.Add();
                numberOfColumns++;
            }

            // Duyệt qua các dòng của DataTable
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                // Thêm dòng mới vào bảng Word nếu cần thiết
                if (i + 2 > tbl.Rows.Count) // +2 vì dòng đầu là tiêu đề
                {
                    tbl.Rows.Add();
                }

                // Duyệt qua các cột của DataTable và điền vào bảng
                for (int j = 0; j < 5; j++)  // Đảm bảo có 6 cột
                {
                    // Thêm dữ liệu vào ô tương ứng trong bảng
                    tbl.Cell(i + 2, j + 1).Range.Text = dataTable.Rows[i][j].ToString();
                }
            }
        }


        // Phương thức xóa Range chứa field
        public void DeleteFieldCompletely(string fieldText)
        {
            foreach (Microsoft.Office.Interop.Word.Range range in _doc.StoryRanges)
            {
                Microsoft.Office.Interop.Word.Find findObject = range.Find;
                findObject.ClearFormatting();
                findObject.Text = fieldText;
                findObject.Forward = true;
                findObject.Wrap = Microsoft.Office.Interop.Word.WdFindWrap.wdFindContinue;
                findObject.Format = false;
                findObject.MatchCase = false;
                findObject.MatchWholeWord = false;
                findObject.MatchWildcards = false;
                findObject.MatchSoundsLike = false;
                findObject.MatchAllWordForms = false;

                while (findObject.Execute(
                    ref missing, ref missing, ref missing, ref missing, ref missing,
                    ref missing, ref missing, ref missing, ref missing, ref missing,
                    ref missing, ref missing, ref missing, ref missing, ref missing))
                {
                    range.Delete();
                    break; // Xóa xong thoát khỏi vòng lặp
                }
            }
        }

        // Phương thức xóa Bookmark
        public void DeleteBookmark(string bookmarkName)
        {
            if (_doc.Bookmarks.Exists(bookmarkName))
            {
                object oName = bookmarkName;
                _doc.Bookmarks.get_Item(ref oName).Delete();
            }
        }



    }
}
