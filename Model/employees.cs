using System;
using System.Collections.Generic;
using System.Text;
using System.IO;


namespace WebCore.Model
{
    public class employees
    {
       
            /// <summary>
            /// 员工编号
            /// </summary>
            public int? id { get; set; }

            /// <summary>
            /// 员工姓名
            /// </summary>
            public string yuangongname { get; set; }

            /// <summary>
            /// 员工工作
            /// </summary>
            public string word { get; set; }

            /// <summary>
            /// 员工直属领导编号
            /// </summary>
            public int? lineManagerId { get; set; }

            /// <summary>
            /// 员工入职时间
            /// </summary>
            public DateTime? entryTime { get; set; }



            /// <summary>
            /// 员工工资
            /// </summary>
            public int? wage { get; set; }

            /// <summary>
            /// 员工奖金
            /// </summary>
            public int? bonus { get; set; }

        

        
    }
}

