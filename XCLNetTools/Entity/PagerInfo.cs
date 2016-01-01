﻿using System;

namespace XCLNetTools.Entity
{
    /// <summary>
    /// 分页信息model
    /// </summary>
    public class PagerInfo
    {
        private PagerInfo()
        {
        }

        /// <summary>
        /// 分页信息 构造函数
        /// </summary>
        public PagerInfo(int pageIndex, int pageSize, int recordCount)
        {
            this.PageIndex = pageIndex <= 0 ? 1 : pageIndex;
            this.PageSize = pageSize <= 0 ? 10 : pageSize;
            this.RecordCount = recordCount <= 0 ? 0 : recordCount;

            if (this.RecordCount > 0)
            {
                this.PageCount = (int)Math.Ceiling((1.0 * this.RecordCount) / this.PageSize);
                this.PageIndex = this.PageIndex > this.PageCount ? this.PageCount : this.PageIndex;
                this.CurrentPageRecordCount = this.PageIndex == this.PageCount && this.RecordCount % this.PageSize > 0 ? this.RecordCount % this.PageSize : this.PageSize;
                this.StartIndex = (this.PageIndex - 1) * this.PageSize + 1;
                this.EndIndex = this.StartIndex + this.CurrentPageRecordCount - 1;
            }
        }

        /// <summary>
        /// 当前页码（第一页为1），默认为1
        /// </summary>
        public int PageIndex { get; set; }

        /// <summary>
        /// 每页最多显示的记录数，默认为10
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// 当前记录总数
        /// </summary>
        public int RecordCount { get; set; }

        /// <summary>
        /// 当前总页数
        /// </summary>
        public int PageCount { get; private set; }

        /// <summary>
        /// 当前页的实际记录条数
        /// </summary>
        public int CurrentPageRecordCount { get; private set; }

        /// <summary>
        /// 当前页的第一条记录的序号
        /// </summary>
        public int StartIndex { get; private set; }

        /// <summary>
        /// 当前页的最后一条记录的序号
        /// </summary>
        public int EndIndex { get; private set; }

        /// <summary>
        /// controller
        /// </summary>
        public string ControllerName { get; set; }

        /// <summary>
        /// action
        /// </summary>
        public string ActionName { get; set; }
    }
}