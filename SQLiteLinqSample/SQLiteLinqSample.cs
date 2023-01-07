/**************************************************************************************************************/
// <copyright file="SQLiteLinqSample.cs" company="Indy"> Copyright © Indy All rights reserved. </copyright>
// <author>Ikuma Uneno</author>
// <email></email>
// <summary>SQLiteを使用したLinqによるサンプル</summary>
/*============================================================================================================*/
// 改修履歴
// No  日付         概要                                                                            担当 
// 001 2023.01.07   初版                                                                            Uneno
// 
/**************************************************************************************************************/

using SQLiteLinqSample.Common;
using SQLiteLinqSample.Database;
using System.Data;
using System.Runtime.Intrinsics.X86;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SQLiteLinqSample
{
    public partial class SampleForm : Form
    {
        #region     ########## プライベートクラス ##########
        #endregion  ########## プライベートクラス ##########
        #region     ########## 定数 ##########
        #endregion  ########## 定数 ##########
        #region     ########## 変数 ##########
        #endregion  ########## 変数 ##########

        #region     ########## コンストラクタ ##########
        public SampleForm()
        {
            InitializeComponent();
            CreateTestDatabaseIfNeeded();
        }
        #endregion  ########## コンストラクタ ##########

        #region     ########## イベント ##########
        #region ************************************************************    FormLoad : 画面ロードイベント
        /// <summary> 画面ロードイベント </summary>
        /// <remarks></remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <returns></returns>
        private void FormLoad(object sender, EventArgs e)
        {
            InitControl();
            InitSearchControl();
            InitDataList();                                                                                             // 一覧表初期化
            GetDataList();                                                                                              // 保存データ表示
        }
        #endregion FormLoad : 画面ロードイベント

        #region ************************************************************    btnSave_Click : データ登録ボタンクリックイベント
        /// <summary> データ登録ボタンクリックイベント </summary>
        /// <remarks></remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <returns></returns>
        private void BtnClick(object sender, EventArgs e)
        {
            System.Windows.Forms.Button ctl = (System.Windows.Forms.Button)sender;

            if (ctl.Name.ToString().Equals("btnSave"))
            {
                if (ValidateSave())                                                                                     // 保存処理前に入力必須項目の検証
                {
                    if (DataSave())                                                                                     // データ保存処理
                    {
                        InitControl();
                        InitDataList();                                                                                 // 一覧表初期化
                        GetDataList();                                                                                  // 保存データ表示
                    }
                }
            }
            else if (ctl.Name.ToString().Equals("btnSearch"))
            {
                InitDataList();                                                                                         // 一覧表初期化
                GetDataList();                                                                                          // 保存データ表示
            }

        }
        #endregion btnSave_Click : データ登録ボタンクリックイベント

        #region ************************************************************    CellContentClick : 一覧表ボタンクリックイベント
        /// <summary> 一覧表ボタンクリックイベント </summary>
        /// <remarks></remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <returns></returns>
        private void CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;

            if (dgv.Rows[e.RowIndex].Cells[0].Value != null)
            {
                
                int dataId = int.Parse(dgv.Rows[e.RowIndex].Cells[0].Value.ToString());
                string name = string.Empty;

                InitControl();// 画面入力コントロールのクリア
                name = dgv.Rows[e.RowIndex].Cells[1].Value.ToString().Trim();
                //"Button"列ならば、ボタンがクリックされた
                if (dgv.Columns[e.ColumnIndex].Name == "BtnEdit")
                {
                    txtDataId.Text = dataId.ToString();
                    txtName.Text = dgv.Rows[e.RowIndex].Cells[1].Value.ToString();
                    if (dgv.Rows[e.RowIndex].Cells[2].Value != null)
                    {
                        txtHeight.Text = dgv.Rows[e.RowIndex].Cells[2].Value.ToString();
                    }
                    txtName.Focus();
                }
                else if (dgv.Columns[e.ColumnIndex].Name == "BtnDel")
                {
                    // メッセージボックスを表示
                    DialogResult result = MessageBox.Show(name + "を削除しますか？", "確認", MessageBoxButtons.OKCancel);
                    if (result.Equals(DialogResult.OK))
                    {
                        DataDelete(dataId);
                        InitDataList();                                                                                         // 一覧表初期化
                        GetDataList();                                                                                          // 保存データ表示
                    }
                }
            }
        }
        #endregion CellContentClick : 一覧表ボタンクリックイベント
        #endregion  ########## イベント ##########

        #region     ########## メソッド ##########
        #region ************************************************************    CreateTestDatabaseIfNeeded : データベースの作成
        /// <summary> データベースの作成 </summary>
        /// <remarks></remarks>
        /// <param></param>
        /// <returns></returns>
        private void CreateTestDatabaseIfNeeded()
        {
            using TestContext testContext = new();
            testContext.Database.EnsureCreated();                                                                       // データベースが存在しない場合は作成
            if (!testContext.TestData.Any())
            {
                // レコードが存在しない場合は作成
                testContext.TestData.Add(new TTestData { Name = "Fukada Kyoko" });
                testContext.TestData.Add(new TTestData { Name = "Eda Ha", Height = 159.0 });
                testContext.TestData.Add(new TTestData { Name = "Dan Gerou", Height = 150.5 });
                testContext.TestData.Add(new TTestData { Name = "Baba Takashi" });
                testContext.TestData.Add(new TTestData { Name = "Aikawa Ai", Height = 145.6 });
                testContext.TestData.Add(new TTestData { Name = "Ccc cc", Height = 120.0 });
                testContext.TestData.Add(new TTestData { Name = "Ggg gg", Height = 165.0 });
                testContext.SaveChanges();
            }
        }
        #endregion CreateTestDatabaseIfNeeded : データベースの作成

        #region ************************************************************    InitControl : 画面コントロールのクリア
        /// <summary> 画面コントロールのクリア </summary>
        /// <remarks></remarks>
        /// <param></param>
        /// <returns></returns>
        private void InitControl()
        {
            txtDataId.Text= string.Empty;
            txtName.Text= string.Empty;
            txtHeight.Text= string.Empty;
        }
        #endregion InitControl : 画面コントロールのクリア

        #region ************************************************************    InitSearchControl : 画面検索コントロールのクリア
        /// <summary> 画面検索コントロールのクリア </summary>
        /// <remarks></remarks>
        /// <param></param>
        /// <returns></returns>
        private void InitSearchControl()
        {
            txtSerchName.Text = string.Empty;
            txtSearchH_Start.Text = string.Empty;
            txtSearchH_End.Text = string.Empty;
        }
        #endregion InitSearchControl : 画面検索コントロールのクリア

        #region ************************************************************    InitDataList : データ一覧表の初期設定
        /// <summary> データベースの作成 </summary>
        /// <remarks></remarks>
        /// <param></param>
        /// <returns></returns>
        private void InitDataList()
        {
            dgvList.Columns.Clear();                                                                                    // リスト列クリア
            dgvList.Rows.Clear();                                                                                       // リスト行クリア

            // ============================================================
            // 【データ部】一覧表へカラム追加してヘッダー表示文字を設定
            // ============================================================
            dgvList.Columns.Add("Id", "Id");
            dgvList.Columns["Id"].Width = 40;
            dgvList.Columns.Add("Title", "名前");
            dgvList.Columns["Title"].Width = 200;
            dgvList.Columns.Add("Height", "身長");
            dgvList.Columns["Height"].Width = 200;
            // ============================================================
            // 【データ制御部】一覧表へカラム追加してボタンに設定
            // ============================================================
            // データ削除ボタン
            DataGridViewButtonColumn column = new DataGridViewButtonColumn                                              //DataGridViewButtonColumnの作成
            {
                Name = "BtnDel",                                                                                        // 列の名前を設定
                UseColumnTextForButtonValue = true,                                                                     // 全てのボタンに表示設定
                Text = "削除"                                                                                           // ボタン表示文字
            };                                           
            dgvList.Columns.Add(column);                                                                                // DataGridViewに追加する
            dgvList.Columns["BtnDel"].Width = 40;
            // データ編集ボタン
            DataGridViewButtonColumn column2 = new DataGridViewButtonColumn
            {
                Name = "BtnEdit",                                                                                       // 列の名前を設定
                UseColumnTextForButtonValue = true,                                                                     // 全てのボタンに表示設定
                Text = "編集"                                                                                           // ボタン表示文字
            };
            dgvList.Columns.Add(column2);                                                                               //DataGridViewに追加する
            dgvList.Columns["BtnEdit"].Width = 40;
        }
        #endregion InitDataList : データ一覧表の初期設定

        #region ************************************************************    GetDataList : データの呼び出し
        /// <summary> データの呼び出し </summary>
        /// <remarks></remarks>
        /// <param></param>
        /// <returns></returns>
        private void GetDataList()
        {
            double heightStart = 0;
            double heightEnd = 0;
            using TestContext conTxt = new();
            List<TTestData> list = conTxt.TestData.ToList();

            // ============================================================
            // 名前の検索データが指定されている場合は条件により検索
            // ============================================================
            if (!txtSerchName.Text.ToString().Trim().Equals(""))
            {
                // 検索の名前が入力されている場合、前方一致で検索処理
                list = list.Where(a => a.Name.StartsWith(txtSerchName.Text.ToString().Trim())).ToList();                
            }
            // ============================================================
            // 身長の検索データを検証・設定
            // ============================================================
            if (!txtSearchH_Start.Text.ToString().Trim().Equals(""))
            {
                heightStart = double.Parse(txtSearchH_Start.Text.ToString().Trim());
            }
            if (!txtSearchH_End.Text.ToString().Trim().Equals(""))
            {
                heightEnd = double.Parse(txtSearchH_End.Text.ToString().Trim());
            }
            // ============================================================
            // 身長の検索データにより検索
            // ============================================================
            if (heightStart > 0 && heightEnd > 0) 
            {
                list = list.Where(a => a.Height >= heightStart)
                           .Where(a => a.Height <= heightEnd)
                           .ToList();
                // 上記の書き方以外の書き方
                // list = list.Where(a => a.Height >= heightStart && a.Height <= heightEnd).ToList();
            }
            else if(heightStart > 0 && heightEnd.Equals(0))
            {
                list = list.Where(a => a.Height >= heightStart).ToList();
            }
            else if (heightStart.Equals(0) && heightEnd > 0)
            {
                list = list.Where(a => a.Height <= heightEnd).ToList();
            }

            int r = 0;
            foreach (TTestData data in list)
            {
                dgvList.Rows.Add();
                dgvList.Rows[r].Cells[0].Value = data.Id;
                dgvList.Rows[r].Cells[1].Value = data.Name.ToString();
                dgvList.Rows[r].Cells[2].Value = data.Height;
                r++;
            }
        }
        #endregion GetDataList : データの呼び出し

        #region ************************************************************    ValidateSave : データ保存前の検証
        /// <summary> データ保存前の検証 </summary>
        /// <remarks></remarks>
        /// <param></param>
        /// <returns> true:検証結果正常, false:検証結果異常 </returns>
        private bool ValidateSave()
        {
            bool ret = true;
            string empItm = string.Empty;
            if (txtName.Text.ToString().Trim().Equals(""))
            {
                ret = false;
                empItm += "【名前】, ";
            }
            if (!ret)
            {
                empItm = empItm.Substring(0, empItm.Length - 2);                                                        // 最後のカンマとスペースを除去
                empItm = "入力必須項目が入力されていないため保存処理が実施できません。" + Const.CRLF + empItm;
                MessageBox.Show(empItm);
            }
            return ret;
        }
        #endregion ValidateSave : データ保存前の検証

        #region ************************************************************    DataSave : データ保存処理
        /// <summary> データ保存処理 </summary>
        /// <remarks></remarks>
        /// <param></param>
        /// <returns> true:保存処理結果正常, false:保存処理結果異常 </returns>
        private bool DataSave()
        {
            bool ret = true;
            using TestContext conTxt = new();
            try
            {
                if (txtDataId.Text.ToString().Trim().Equals(""))
                {
                    // ============================================================
                    // データ新規保存
                    // ============================================================
                    int nxtId = conTxt.TestData.Max(a => a.Id) + 1;                                                     // IDの最大値を取得し、インクリメントする。
                    TTestData newData = new TTestData();
                    newData.Name = txtName.Text.ToString();
                    if (!txtHeight.Text.ToString().Trim().Equals(""))
                    {
                        newData.Height = double.Parse(txtHeight.Text.ToString());
                    }
                    conTxt.TestData.Add(newData);
                }
                else
                {
                    // ============================================================
                    // データ更新保存
                    // ============================================================
                    int dataId = Int32.Parse(txtDataId.Text.ToString());
                    TTestData target = conTxt.TestData.SingleOrDefault(a => a.Id == dataId);
                    if (target != null)
                    {
                        target.Name = txtName.Text.ToString();
                        target.Height = double.Parse(txtHeight.Text.ToString());
                    }
                }
                conTxt.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);                                                                  
                ret = false;                                                                                   
            }
            return ret;
        }
        #endregion DataSave : データ保存処理
        #region ************************************************************    DataDelete : データ削除処理
        /// <summary> データ保存処理 </summary>
        /// <remarks></remarks>
        /// <param></param>
        /// <returns> true:保存処理結果正常, false:保存処理結果異常 </returns>
        private void DataDelete(int targetId)
        {
            using TestContext conTxt = new();
            try
            {
                TTestData targetData = conTxt.TestData.SingleOrDefault(a => a.Id == targetId);
                if (targetData != null) 
                { 
                    conTxt.TestData.Remove(targetData);
                    conTxt.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        #endregion DataDelete : データ削除処理

        #endregion  ########## メソッド ##########

    }
}