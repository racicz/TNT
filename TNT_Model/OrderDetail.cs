using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TNT_Model
{
    public class OrderDetail
    {
        public int OrderDetailId { get; set; }
        public int OrderId { get; set; }
        public int FishTypeId { get; set; }
        public int StatusId { get; set; }
        public decimal OrderKg { get; set; }
        public decimal PricePerKg { get; set; }
        public decimal DeliveredKg { get; set; }
        public string Notes { get; set; }
        public decimal AmountDue { get; set; }
        public decimal AmountPaid { get; set; }
        public string Preparations { get; set; }
        public string Action { get; set; }
        public virtual FishType FishType { get; set; }
        public virtual Status Status { get; set; }
        public virtual Order Order { get; set; }
        
    }

    public class OrderDetails : List<OrderDetail>, IEnumerable<SqlDataRecord>
    {
        IEnumerator<SqlDataRecord> IEnumerable<SqlDataRecord>.GetEnumerator()
        {
            SqlDataRecord rec = new SqlDataRecord(
                        new SqlMetaData("OrderDetailId", System.Data.SqlDbType.Int),
                        new SqlMetaData("FishTypeId", System.Data.SqlDbType.Int),
                        new SqlMetaData("FishName", System.Data.SqlDbType.VarChar,50),
                        new SqlMetaData("StatusId", System.Data.SqlDbType.Int),
                        new SqlMetaData("OrderKg", System.Data.SqlDbType.Decimal, 12, 2),
                        new SqlMetaData("DeliveredKg", System.Data.SqlDbType.Decimal, 12, 2),
                        new SqlMetaData("Notes", System.Data.SqlDbType.VarChar, -1),
                        new SqlMetaData("AmountDue", System.Data.SqlDbType.Decimal, 12, 2),
                        new SqlMetaData("AmountPaid", System.Data.SqlDbType.Decimal, 12, 2),
                        new SqlMetaData("Preparations", System.Data.SqlDbType.VarChar, 50),
                        new SqlMetaData("Status", System.Data.SqlDbType.VarChar, 1)
                );


            foreach (OrderDetail det in this)
            {
                rec.SetInt32(0, det.OrderDetailId);
                rec.SetInt32(1, det.FishTypeId);
                rec.SetString(2, det.FishType.Description ?? string.Empty);
                rec.SetInt32(3, det.StatusId);
                rec.SetDecimal(4, det.OrderKg);
                rec.SetDecimal(5, det.DeliveredKg);
                rec.SetString(6, det.Notes ?? string.Empty);
                rec.SetDecimal(7, det.AmountDue);
                rec.SetDecimal(8, det.AmountPaid);
                rec.SetString(9, det.Preparations ?? string.Empty);
                rec.SetString(10, det.Action ?? string.Empty);
                yield return rec;
            }
        }
    }
}
