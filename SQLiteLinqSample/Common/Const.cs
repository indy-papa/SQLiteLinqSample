/**************************************************************************************************************/
// <copyright file="Const.cs" company="Indy"> Copyright © Indy All rights reserved. </copyright>
// </copyright>
// <author>Ikuma Uneno</author>
// <email></email>
// <summary> 共通定義 </summary>
/*============================================================================================================*/
// 改修履歴
// No  日付         概要                                                                            担当 
// 001 2023.01.07   初版                                                                            Uneno
// 
/**************************************************************************************************************/

namespace SQLiteLinqSample.Common
{
    internal class Const
    {
        /// <summary>改行コード</summary>
        public const string CRLF = "\r\n";

        #region ************************************************************    GetMyDocumentPath : ユーザーのマイドキュメントのパスを取得する
        /// <summary> ユーザーのマイドキュメントのパスを取得する </summary>
        /// <remarks></remarks>
        /// <param></param>
        /// <returns> 取得したパス </returns>
        public static string GetMyDocumentPath()
        {
            return System.Environment.GetFolderPath(Environment.SpecialFolder.Personal);
        }
        #endregion GetMyDocumentPath : ユーザーのマイドキュメントのパスを取得する

        #region ************************************************************    GetExcelTemplatePath : Excelテンプレートのパスを取得する
        /// <summary> Excelテンプレートのパスを取得する </summary>
        /// <remarks></remarks>
        /// <param></param>
        /// <returns> 取得したパス </returns>
        public static string GetExcelTemplatePath()
        {
            return System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\\Excel\\";
        }
        #endregion GetExcelTemplatePath : Excelテンプレートのパスを取得する


    }
}
