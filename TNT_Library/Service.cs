using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TNT_Model;
using TNT_Model.Response;

namespace TNT_Library
{
    public class Service
    {
        SqlConnection cnn;
        SqlDataAdapter da;
        SqlCommand cmd;
        SqlDataReader dr;

        string errorPath = string.Empty;
        string strConn = string.Empty;

        public Service()
        {
            this.errorPath = ConfigurationManager.AppSettings["ErrorPath"] + "\\ErrorLog-" + DateTime.Now.ToString("d").Replace("/", "-") + ".txt";
            this.strConn = ConfigurationManager.ConnectionStrings["TNT.Conn"].ConnectionString;
        }
#region Get

        public List<FishType> GetFishType
        {
            get
            {
                List<FishType> types = new List<FishType>();

                try
                {
                    using (cnn = new SqlConnection(strConn))
                    {
                        using (cmd = new SqlCommand(@"SELECT FishTypeId,Description, Price
                                                          FROM FishType 
                                                      Where Deleted = 0
                                                      Order By Description", cnn))
                        {
                            cnn.Open();
                            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                            CultureInfo ci = new CultureInfo("sr-Latn");

                            while (dr.Read())
                            {
                                var prep = GetFishTypePreparation(Convert.ToInt32(dr["FishTypeId"]), "fish");

                                types.Add(new FishType()
                                {
                                    FishTypeId = Convert.ToInt32(dr["FishTypeId"]),
                                    Description = dr["Description"].ToString(),
                                    Preparations = prep,
                                    PrepSelected = prep != null && prep.Count > 0 ? prep.Select(t => t.Description).FirstOrDefault() : string.Empty,
                                    Price = dr["Price"] != DBNull.Value ? Convert.ToDecimal(dr["Price"],ci) : 0
                                });
                            }
                        }

                    }

                    return types;
                }
                catch (Exception ex)
                { ErrorLog = ex.ToString(); return null; }
            }
        }

        public List<Preparation> GetFishTypePreparation(int id, string type)
        {

            List<Preparation> prep = new List<Preparation>();

            using (DataTable dt = new DataTable("Preparation"))
            {
                try
                {
                    string sql = "";

                    if (type == "order")
                    {
                        sql = string.Format(@"SELECT Preparation.PreparationId, Preparation.Description
                                                    FROM Preparation inner join
		                                                    OrderDetailPreparation on Preparation.PreparationId = OrderDetailPreparation.PreparationId
                                                Where OrderDetailPreparation.OrderDetailId = {0}
                                                Order By Description", id);
                    }
                    else
                    {
                        sql = string.Format(@"SELECT Preparation.PreparationId, Preparation.Description
                                                    FROM Preparation inner join
		                                                    FishTypePreparation on Preparation.PreparationId = FishTypePreparation.PreparationId
                                                Where FishTypeId = {0}
                                                Order By Description", id);
                    }

                    using (cnn = new SqlConnection(strConn))
                    {
                        using (da = new SqlDataAdapter(sql, cnn))
                        {

                            da.Fill(dt);
                            int cnt = dt.Rows.Count;

                            foreach (DataRow dr in dt.Rows)
                            {
                                prep.Add(new Preparation()
                                {
                                    PreparationId = Convert.ToInt32(dr["PreparationId"]),
                                    Description = dr["Description"].ToString(),
                                    Count = cnt.ToString()
                                });

                                cnt--;
                            }
                        }

                    }

                    return prep;
                }
                catch (Exception ex)
                { ErrorLog = ex.ToString(); return null; }
            }

        }

        public List<Status> GetStatus
        {
            get
            {
                List<Status> status = new List<Status>();

                try
                {
                    using (cnn = new SqlConnection(strConn))
                    {
                        using (cmd = new SqlCommand(@"SELECT StatusId,Description
                                                          FROM Status 
                                                      Order By Description", cnn))
                        {
                            cnn.Open();
                            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

                            while (dr.Read())
                            {
                                status.Add(new Status()
                                {
                                    StatusId = Convert.ToInt32(dr["StatusId"]),
                                    Description = dr["Description"].ToString()
                                });
                            }
                        }

                    }

                    return status;
                }
                catch (Exception ex)
                { ErrorLog = ex.ToString(); return null; }
            }
        }

        public List<Town> GetTowns
        {
            get
            {
                List<Town> towns = new List<Town>();

                try
                {
                    using (cnn = new SqlConnection(strConn))
                    {
                        using (cmd = new SqlCommand(@"SELECT TownId,TownName
                                                          FROM Town 
                                                      Order By TownName", cnn))
                        {
                            cnn.Open();
                            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

                            while (dr.Read())
                            {
                                towns.Add(new Town()
                                {
                                    TownId = Convert.ToInt32(dr["TownId"]),
                                    TownName = dr["TownName"].ToString()
                                });
                            }
                        }

                    }

                    return towns;
                }
                catch (Exception ex)
                { ErrorLog = ex.ToString(); return null; }
            }
        }

        public int GetNextAutoNumber
        {
            get
            {
                try
                {
                    using (cnn = new SqlConnection(strConn))
                    {
                        using (cmd = new SqlCommand(@"SELECT top 1 ordernumber + 1 [NextOrderNumber]
	                                                    FROM [Order]
                                                    Order by ordernumber desc", cnn))
                        {
                            cnn.Open();
                            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

                            while (dr.Read())
                            {
                                return Convert.ToInt32(dr["NextOrderNumber"]);
                            }
                        }

                    }

                    return 0;

                }
                catch (Exception ex)
                { ErrorLog = ex.ToString(); return 0; }
            }
        }

        public List<Contact> GetSubjectContact(int sbjid)
        {
            List<Contact> contacts = new List<Contact>();

            try
            {
                using (cnn = new SqlConnection(strConn))
                {
                    using (cmd = new SqlCommand(string.Format(@"Select SubjectContactTypeId, ContactValue
	                                                                From contact
                                                                Where SubjectId = {0}", sbjid), cnn))
                    {
                        cnn.Open();
                        dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

                        while (dr.Read())
                        {
                            contacts.Add(new Contact()
                            {
                                SubjectContactTypeId = Convert.ToInt32(dr["SubjectContactTypeId"]),
                                ContactValue = dr["ContactValue"] != DBNull.Value ? dr["ContactValue"].ToString() : string.Empty
                            });
                        }

                        return contacts;
                    }

                }

            }
            catch (Exception ex)
            { ErrorLog = ex.ToString(); return null; }

        }

        public List<ContactPerson> GetContacts
        {
            get
            {
                List<ContactPerson> contacts = new List<ContactPerson>();

                try
                {
                    using (cnn = new SqlConnection(strConn))
                    {
                        using (cmd = new SqlCommand(@"Select Person.Subjectid, Name, TownName [Town], ContactValue, Ord.LastOrderNumber
                                                        From person inner join
	                                                         Subject on Person.SubjectId = Subject.Subjectid left join
	                                                         Town on Subject.TownId = Town.TownId left join
	                                                         (select SubjectId, ContactValue, ROW_NUMBER() OVER (PARTITION BY subjectid ORDER BY subjectcontactid) AS rn
		                                                        from contact) as c on person.SubjectId = c.SubjectId left join
                                                             (SELECT subjectid,  max(OrderNumber) [LastOrderNumber]
                                                                FROM [dbo].[Order] 
                                                              Group by subjectid) as Ord on Person.Subjectid = Ord.Subjectid
                                                        Where (rn is null or rn = 1)
                                                        Order By Name, TownName", cnn))
                        {
                            cnn.Open();
                            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

                            while (dr.Read())
                            {
                                contacts.Add(new ContactPerson()
                                {
                                    LastOrderNumber = dr["LastOrderNumber"] != DBNull.Value ? Convert.ToInt32(dr["LastOrderNumber"]) : 0,
                                    Person = new Person()
                                    {
                                        SubjectId = Convert.ToInt32(dr["SubjectId"]),
                                        Name = dr["Name"].ToString(),
                                        Town = dr["Town"] != DBNull.Value ? dr["Town"].ToString() : string.Empty
                                    },
                                    Contact = new Contact()
                                    {
                                        SubjectId = Convert.ToInt32(dr["SubjectId"]),
                                        ContactValue = dr["ContactValue"] != DBNull.Value ? dr["ContactValue"].ToString() : string.Empty
                                    }
                                });

                            }
                        }

                    }

                    return contacts;
                }
                catch (Exception ex)
                { ErrorLog = ex.ToString(); return null; }
            }
        }

        public List<Search> GetSearchResults(string where)
        {

            List<Search> results = new List<Search>();

            try
            {
                using (cnn = new SqlConnection(strConn))
                {
                    using (cmd = new SqlCommand(string.Format(@"SELECT ord.OrderId, OrderNumber, OrderDate, OrderTime, DeliveryDate, DeliveryTime, Subject.SubjectId, Name, TownName, Phone, TotalNo, Due
                                                                  FROM [Order] ord inner join
	                                                                   Person on ord.subjectid = person.subjectid inner join
	                                                                   Subject on person.subjectid = subject.SubjectId left join
	                                                                   Town on subject.townid = town.townid inner join
	                                                                   (select OrderId, count(*) [TotalNo], sum(AmountDue) [Due]
				                                                                from OrderDetail 
		                                                                where Deleted = 0
		                                                                group by OrderId) as det on ord.OrderId = det.OrderId left join
		                                                                (select SubjectId, ContactValue [Phone]
				                                                                from Contact
		                                                                 where  subjectcontacttypeid = 2) as ph on Person.SubjectId = ph.SubjectId 
                                                                {0}
                                                                Order by OrderNumber desc", where), cnn))
                    {
                        cnn.Open();
                        dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                        CultureInfo ci = new CultureInfo("sr-Latn");

                        while (dr.Read())
                        {
                            if (results.Where(t => t.Person.SubjectId == Convert.ToInt32(dr["SubjectId"])).Count() == 0)
                            {
                                List<Order> orders = new List<Order>();
                                orders.Add(new Order()
                                {
                                    OrderId = Convert.ToInt32(dr["OrderId"]),
                                    OrderNumber = dr["OrderNumber"].ToString(),
                                    OrderDate = dr["OrderDate"] != DBNull.Value ? Convert.ToDateTime(dr["OrderDate"]).ToString("d", ci) : string.Empty,
                                    OrderTime = dr["OrderTime"] != DBNull.Value ? Convert.ToDateTime(dr["OrderTime"]).ToString("t", ci) : string.Empty,
                                    DeliveryDate = dr["DeliveryDate"] != DBNull.Value ? Convert.ToDateTime(dr["DeliveryDate"]).ToString("d", ci) : string.Empty,
                                    DeliveryTime = dr["DeliveryTime"] != DBNull.Value ? Convert.ToDateTime(dr["DeliveryTime"]).ToString("t", ci) : string.Empty,
                                });

                                var person = new Person()
                                {
                                    SubjectId = Convert.ToInt32(dr["SubjectId"]),
                                    Name = dr["Name"] != DBNull.Value ? dr["Name"].ToString() : string.Empty,
                                    Town = dr["TownName"] != DBNull.Value ? dr["TownName"].ToString() : string.Empty,
                                    CellPhone = dr["Phone"] != DBNull.Value ? dr["Phone"].ToString() : string.Empty,
                                    Orders = orders
                                };

                                results.Add(new Search()
                                {
                                    Person = person,
                                    TotalNo = dr["TotalNo"] != DBNull.Value ? Convert.ToDecimal(dr["TotalNo"]) : 0,
                                    Due = dr["Due"] != DBNull.Value ? Convert.ToDecimal(dr["Due"]) : 0
                                });
                                
                            }
                            else
                            {
                                var search = results.Where(t => t.Person.SubjectId == Convert.ToInt32(dr["SubjectId"])).FirstOrDefault();

                                if (search != null)
                                {
                                    Order ord = new Order()
                                    {
                                        OrderId = Convert.ToInt32(dr["OrderId"]),
                                        OrderNumber = dr["OrderNumber"].ToString(),
                                        OrderDate = dr["OrderDate"] != DBNull.Value ? Convert.ToDateTime(dr["OrderDate"]).ToString("d", ci) : string.Empty,
                                        OrderTime = dr["OrderTime"] != DBNull.Value ? Convert.ToDateTime(dr["OrderTime"]).ToString("t", ci) : string.Empty,
                                        DeliveryDate = dr["DeliveryDate"] != DBNull.Value ? Convert.ToDateTime(dr["DeliveryDate"]).ToString("d", ci) : string.Empty,
                                        DeliveryTime = dr["DeliveryTime"] != DBNull.Value ? Convert.ToDateTime(dr["DeliveryTime"]).ToString("t", ci) : string.Empty
                                    };

                                    search.Person.Orders.Add(ord);
                                    search.Due += dr["Due"] != DBNull.Value ? Convert.ToDecimal(dr["Due"]) : 0;
                                    search.TotalNo += dr["TotalNo"] != DBNull.Value ? Convert.ToDecimal(dr["TotalNo"]) : 0;
                                }

                            }

                            
                        }
                    }

                }

                return results;
            }
            catch (Exception ex)
            { ErrorLog = ex.ToString(); return null; }

        }

        public List<OrderDetail> GetOrderDetails(int orderId)
        {
            List<OrderDetail> results = new List<OrderDetail>();

            try
            {
                using (cnn = new SqlConnection(strConn))
                {
                    using (cmd = new SqlCommand(string.Format(@"SELECT OrderDetailId, OrderKg, DeliveredKg, AmountDue, 
                                                                        AmountPaid, FishType.FishTypeId, FishType.Description [FishType], 
                                                                        Status.StatusId, Status.Description [Status], OrderDetail.Notes
                                                                    FROM OrderDetail inner join
			                                                             FishType on OrderDetail.FishTypeId = FishType.FishTypeId inner join
			                                                             Status on OrderDetail.StatusId = Status.StatusId
                                                                Where OrderDetail.Deleted = 0 and OrderDetail.OrderId = {0}
                                                            Order by OrderDetailId desc", orderId), cnn))
                    {
                        cnn.Open();
                        dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                        CultureInfo ci = new CultureInfo("sr-Latn");

                        while (dr.Read())
                        {
                            results.Add(new OrderDetail()
                            {
                                OrderDetailId = Convert.ToInt32(dr["OrderDetailId"]),
                                OrderKg = dr["OrderKg"] != DBNull.Value ? Convert.ToDecimal(dr["OrderKg"], ci) : 0,
                                DeliveredKg = dr["DeliveredKg"] != DBNull.Value ? Convert.ToDecimal(dr["DeliveredKg"], ci) : 0,
                                AmountDue = dr["AmountDue"] != DBNull.Value ? Convert.ToDecimal(dr["AmountDue"], ci) : 0,
                                AmountPaid = dr["AmountPaid"] != DBNull.Value ? Convert.ToDecimal(dr["AmountPaid"], ci) : 0,
                                FishTypeId = Convert.ToInt32(dr["FishTypeId"]),
                                FishType = new FishType()
                                {
                                    FishTypeId = Convert.ToInt32(dr["FishTypeId"]),
                                    Description = dr["FishType"] != DBNull.Value ? dr["FishType"].ToString() : string.Empty,
                                    Price = (dr["AmountDue"] != DBNull.Value ? Convert.ToDecimal(dr["AmountDue"], ci) : 0) > 0 ? ((dr["AmountDue"] != DBNull.Value ? Convert.ToDecimal(dr["AmountDue"], ci) : 0) / (dr["OrderKg"] != DBNull.Value ? Convert.ToDecimal(dr["OrderKg"], ci) : 0)) : 0,
                                    Preparations = GetFishTypePreparation(Convert.ToInt32(dr["OrderDetailId"]), "order")
                                },
                                StatusId = Convert.ToInt32(dr["StatusId"]),
                                Status = new Status()
                                {
                                    StatusId = Convert.ToInt32(dr["StatusId"]),
                                    Description = dr["Status"] != DBNull.Value ? dr["Status"].ToString() : string.Empty
                                },
                                Notes = dr["Notes"] != DBNull.Value ? dr["Notes"].ToString() : string.Empty,
                            });
                        }
                    }

                }

                return results;
            }
            catch (Exception ex)
            { ErrorLog = ex.ToString(); return null; }
        }

        public List<Preparation> GetPreparations()
        {
            List<Preparation> preparations = new List<Preparation>();

            try
            {
                using (cnn = new SqlConnection(strConn))
                {
                    using (cmd = new SqlCommand(@"Select PreparationId, Description
	                                                    From Preparation
                                                    Order By Description", cnn))
                    {
                        cnn.Open();
                        dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

                        while (dr.Read())
                        {
                            preparations.Add(new Preparation()
                            {
                                PreparationId = Convert.ToInt32(dr["PreparationId"]),
                                Description = dr["Description"] != DBNull.Value ? dr["Description"].ToString() : string.Empty,
                                IsSelected = false
                            });
                        }

                        return preparations;
                    }

                }

            }
            catch (Exception ex)
            { ErrorLog = ex.ToString(); return null; }
        }

        #endregion

        public Response IsOrderSaved(Order order)
        {
            using (var cnn = new SqlConnection(strConn))
            {
                using (var cmd = new SqlCommand("dbo.sp_save_order", cnn))
                {
                    Response response = new Response();

                    try
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandTimeout = 1200;
                        cmd.Parameters.Add(new SqlParameter("@return_value", SqlDbType.Int)).Direction = ParameterDirection.ReturnValue;
                        cmd.Parameters.Add(new SqlParameter("@Id", SqlDbType.Int)).Value = order.OrderId;
                        cmd.Parameters.Add(new SqlParameter("@OrderNo", SqlDbType.Int)).Value = order.OrderNumber;
                        cmd.Parameters.Add(new SqlParameter("@OrderDate", SqlDbType.VarChar,10)).Value = order.OrderDate;
                        cmd.Parameters.Add(new SqlParameter("@OrderTime", SqlDbType.VarChar, 10)).Value = order.OrderTime;
                        cmd.Parameters.Add(new SqlParameter("@DeliveryDate", SqlDbType.VarChar, 10)).Value = order.DeliveryDate;
                        cmd.Parameters.Add(new SqlParameter("@DeliveryTime", SqlDbType.VarChar, 10)).Value = order.DeliveryTime;
                        cmd.Parameters.Add(new SqlParameter("@SubjectId", SqlDbType.Int)).Value = order.SubjectId;
                        cmd.Parameters.Add(new SqlParameter("@HomePhone", SqlDbType.VarChar,50)).Value = order.Person.HomePhone ?? string.Empty;
                        cmd.Parameters.Add(new SqlParameter("@CellPhone", SqlDbType.VarChar, 50)).Value = order.Person.CellPhone ?? string.Empty;
                        cmd.Parameters.Add(new SqlParameter("@Email", SqlDbType.VarChar, 50)).Value = order.Person.Email ?? string.Empty;
                        cmd.Parameters.Add(new SqlParameter("@Name", SqlDbType.VarChar, 50)).Value = order.Person.Name ?? string.Empty;
                        cmd.Parameters.Add(new SqlParameter("@TownName", SqlDbType.VarChar, 50)).Value = order.Person.Town ?? string.Empty;
                        cmd.Parameters.Add(new SqlParameter("@Details", SqlDbType.Structured)).Value = GetTVPTypes(order.OrderDetails);
                        cmd.Parameters.Add(new SqlParameter("@msg", SqlDbType.VarChar, 8000)).Direction = ParameterDirection.Output;

                        cnn.Open();
                        cmd.ExecuteNonQuery();

                        if (Convert.ToInt32(cmd.Parameters["@return_value"].Value) < 0)
                        {
                            response.Msg = cmd.Parameters["@msg"].Value.ToString();
                            response.Return = false;
                        }
                        else
                        {
                            response.Msg = cmd.Parameters["@msg"].Value.ToString();
                            response.Return = true;
                            response.ReturnValue = Convert.ToInt32(cmd.Parameters["@return_value"].Value);
                        }

                    }
                    catch (Exception ex)
                    {
                        response.Msg = ex.ToString();
                        response.Return = false;
                        ErrorLog = ex.ToString();
                    }

                    return response;
                }
            }
        }

        private OrderDetails GetTVPTypes(List<OrderDetail> details)
        {
            OrderDetails d = new OrderDetails();

            foreach (OrderDetail det in details)
                d.Add(det);

            return d;
        }

        public Response IsFishTypeSaved(FishType type)
        {
            using (var cnn = new SqlConnection(strConn))
            {
                using (var cmd = new SqlCommand("dbo.sp_save_fish", cnn))
                {
                    Response response = new Response();

                    try
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandTimeout = 1200;
                        cmd.Parameters.Add(new SqlParameter("@return_value", SqlDbType.Int)).Direction = ParameterDirection.ReturnValue;
                        cmd.Parameters.Add(new SqlParameter("@Id", SqlDbType.Int)).Value = type.FishTypeId;
                        cmd.Parameters.Add(new SqlParameter("@FishType", SqlDbType.VarChar,50)).Value = type.Description;
                        cmd.Parameters.Add(new SqlParameter("@Price", SqlDbType.Decimal)).Value = type.Price;
                        cmd.Parameters.Add(new SqlParameter("@Status", SqlDbType.VarChar, 1)).Value = type.Status;
                        cmd.Parameters.Add(new SqlParameter("@Preparations", SqlDbType.VarChar, -1)).Value = type.Preparations != null && type.Preparations.Count() > 0 ? string.Join("~", type.Preparations.Select(t => t.PreparationId.ToString())) : string.Empty;
                        cmd.Parameters.Add(new SqlParameter("@msg", SqlDbType.VarChar, 8000)).Direction = ParameterDirection.Output;

                        cnn.Open();
                        cmd.ExecuteNonQuery();

                        if (Convert.ToInt32(cmd.Parameters["@return_value"].Value) < 0)
                        {
                            response.Msg = cmd.Parameters["@msg"].Value.ToString();
                            response.Return = false;
                        }
                        else
                        {
                            response.Msg = cmd.Parameters["@msg"].Value.ToString();
                            response.Return = true;
                            response.ReturnValue = Convert.ToInt32(cmd.Parameters["@return_value"].Value);
                        }

                    }
                    catch (Exception ex)
                    {
                        response.Msg = ex.ToString();
                        response.Return = false;
                        ErrorLog = ex.ToString();
                    }

                    return response;
                }
            }
        }

        public Response IsStatusChanged(Order order, int statusId)
        {
            using (var cnn = new SqlConnection(strConn))
            {
                using (var cmd = new SqlCommand(string.Format(@"update OrderDetail
                                                                    set statusId = {0}
                                                                where OrderId = {1}", statusId, order.OrderId), cnn))
                {
                    Response response = new Response();

                    try
                    {

                        cnn.Open();
                        cmd.ExecuteNonQuery();
                        response.Msg = "Status Promenjen.";
                        response.Return = true;

                    }
                    catch (Exception ex)
                    {
                        response.Msg = ex.ToString();
                        response.Return = false;
                        ErrorLog = ex.ToString();
                    }

                    return response;
                }
            }
        }

        private string ErrorLog
        {
            set
            {
                TextWriter writer = new StreamWriter(errorPath, true);
                writer.WriteLine(value);
                writer.Close();
            }
        }
    }
}
