﻿#region 说明
//---------------------------------------名称:封装的正则表达式处理类
//---------------------------------------版本:1.2.0.0
//---------------------------------------更新时间:2017/11/03
//---------------------------------------作者:献丑
//---------------------------------------CSDN:http://blog.csdn.net/qq_26712977
//---------------------------------------GitHub:https://github.com/a462247201/Tools
#endregion

#region 名空间
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
#endregion

namespace ExtractLib
{
    /// <summary>
    /// 使用正则表达式抽取文本内容
    /// </summary>
    public class RegexMethod
    {
        #region 方法
		// <summary>
        /// 抽取单条
        /// </summary>
        /// <param name="Regstr">正则表达式字符串</param>
        /// <param name="Txt">待匹配的文本</param>
        /// <returns></returns>
        public static String GetSingleResult(String Regstr, String Txt, bool MatchCheck = false)
        {
            String retStr = String.Empty;
            if (String.IsNullOrEmpty(Txt))
            {
                return String.Empty;
            }
            if (!String.IsNullOrEmpty(Regstr))
            {
                Regex reg = new Regex(Regstr);
                if (MatchCheck)
                {
                    if (reg.IsMatch(Txt))
                    {
                        return String.Empty;
                    }
                }
                var match = reg.Match(Txt);
                if (match == null)
                {
                    return String.Empty;
                }
                return reg.Match(Txt).Value;
        
            }
            return retStr;
        }
        /// <summary>
        /// 抽取单条 指定层数
        /// </summary>
        /// <param name="Regstr">正则表达式字符串</param>
        /// <param name="Txt">待匹配的文本</param>
        /// <param name="Layer">抽取层数</param>
        /// <param name="MatchCheck">是否检查匹配</param>
        /// <returns></returns>
        public static String GetSingleResult(String Regstr, String Txt, int Layer,bool MatchCheck = false)
        {
            String retStr = String.Empty;
            if(String.IsNullOrEmpty(Txt))
            {
                return String.Empty;
            }
            if (!String.IsNullOrEmpty(Regstr))
            {
                Regex reg = new Regex(Regstr);
                if(MatchCheck)
                {
                    if (reg.IsMatch(Txt))
                    {
                        return String.Empty;
                    }
                }
                retStr = reg.Match(Txt).Groups[Layer].Value;
                if (!String.IsNullOrEmpty(retStr))
                {
                    retStr = retStr.Trim();
                }
                reg = null;
            }
            return retStr;
        }
        /// <summary>
        /// 抽取多条
        /// </summary>
        /// <param name="Regstr">正则表达式字符串</param>
        /// <param name="Txt">待匹配的文本</param>
        /// <param name="regop">是否匹配大小写</param>
        /// <param name="MatchCheck">是否检查匹配</param>
        /// <returns></returns>
        public static List<String> GetMutResult(String Regstr, String Txt, RegexOptions regop = RegexOptions.None, bool MatchCheck = false)
        {
            if(String.IsNullOrEmpty(Txt))
            {
                return null;
            }
            List<String> RetList = new List<string>();
            if (!String.IsNullOrEmpty(Regstr))
            {
                Regex reg = new Regex(Regstr,regop);
                if(MatchCheck)
                {
                    if (reg.IsMatch(Txt))
                    {
                        return RetList;
                    }
                }
                MatchCollection mc = reg.Matches(Txt);
                if(mc!=null)
                {
                    foreach (Match m in mc)
                    {
                        RetList.Add(m.Value);
                    }
                }
            }
            return RetList;
        }
        /// <summary>
        /// 抽取多条 指定层数
        /// </summary>
        /// <param name="Regstr">正则表达式字符串</param>
        /// <param name="Txt">待匹配的文本</param>
        /// <param name="Layer">抽取层数</param>
        /// <param name="MatchCheck">是否检查匹配</param>
        /// <returns></returns>
        public static List<String> GetMutResult(String Regstr, String Txt, int Layer,bool MatchCheck = false)
        {
            if(String.IsNullOrEmpty(Txt))
            {
                return null;
            }
            List<String> RetList = new List<string>();
            if (!String.IsNullOrEmpty(Regstr))
            {
                Regex reg = new Regex(Regstr);
                if (MatchCheck)
                {
                    if (reg.IsMatch(Txt))
                    {
                        return RetList;
                    }
                }
                MatchCollection mc = reg.Matches(Txt);
                if (mc != null)
                {
                    foreach (Match m in mc)
                    {
                        RetList.Add(m.Groups[Layer].Value);
                    }
                }
            }
            return RetList;
        }
        /// <summary>
        /// 使用正则表达式替换文本
        /// </summary>
        /// <param name="Regstr">正则表达式字符串</param>
        /// <param name="Txt">待替换的文本</param>
        /// <param name="Repstr">代替的文本</param>
        /// <returns>返回替换后的文本</returns>
        public static String RegReplace(String Regstr, String Txt, String Repstr)
        {
            if (String.IsNullOrEmpty(Txt))
            {
                return String.Empty;
            }
            Regex reg = new Regex(Regstr);
            return reg.Replace(Txt, Repstr);
        }
        /// <summary>
        /// 检验正则表达式是否有匹配
        /// </summary>
        /// <param name="Regstr"></param>
        /// <param name="Txt"></param>
        /// <returns></returns>
        public static bool CheckRegex(String Regstr, String Txt)
        {
            if(String.IsNullOrEmpty(Txt))
            {
                return false;
            }
            Regex reg = new Regex(Regstr);
            return reg.IsMatch(Txt);
        }
        /// <summary>
        /// 使用正则表达式分割文本 返回String[]
        /// </summary>
        /// <param name="Regstr">字符串类型的正则表达式</param>
        /// <param name="Txt">待分割的文本</param>
        /// <returns></returns>
        public static String[] RegSplit(String Regstr,String Txt)
        {
            if (String.IsNullOrEmpty(Txt))
            {
                return null;
            }
            Regex reg = new Regex(Regstr);
            return reg.Split(Txt);
        }
        /// <summary>
        /// 获得文本中第一条匹配的数字文本
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="p"></param>
        /// <returns></returns>
        public static String GetNum<T>(T p)
        {
            String str = RegexMethod.GetSingleResult("[0-9]+",Convert.ToString(p));
            if(String.IsNullOrEmpty(str))
            {
                return String.Empty;
            }
            return str;
        } 
	#endregion
    }
}
