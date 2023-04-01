namespace WebCore.ViewModel
{
    public class Users
    {
        /// <summary>
        /// 员工编号
        /// </summary>
        public int? Id { get; set; }

        /// <summary>
        /// 员工姓名
        /// </summary>
        public string Yuangongname { get; set; }

        /// <summary>
        /// 员工工作
        /// </summary>
        public string Word { get; set; }

        /// <summary>
        /// 员工直属领导编号
        /// </summary>
        public int? LineManagerId { get; set; }

        /// <summary>
        /// 员工入职时间
        /// </summary>
        public DateTime? EntryTime { get; set; }



        /// <summary>
        /// 员工工资
        /// </summary>
        public int? Wage { get; set; }

        /// <summary>
        /// 员工奖金
        /// </summary>
        public int? Bonus { get; set; }
    }
}
