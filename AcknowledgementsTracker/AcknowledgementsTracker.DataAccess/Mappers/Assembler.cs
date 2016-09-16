//-----------------------------------------------------------------------
// <copyright file="Assembler.cs" company="Proxiad Bulgaria">
//     Copyright (c) Proxiad Bulgaria. All rights reserved.
// </copyright>
// <author>Ilia Anastassov</author>
//-----------------------------------------------------------------------
namespace AcknowledgementsTracker.DataAccess.Mappers
{
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using Context;

    // TODO: Use of DbContext or not?
    public class Assembler
    {
        public static DataSet CreateAcknowledgementDto(int id)
        {
            ////using (var context = new AcknowledgementsTrackerContext())
            ////{
            ////    context.Acknowledgements.Find(id);
            ////}

            SqlConnection myConntection = new SqlConnection(@"server=.\SQLEXPRESS;database=AcknowledgementsTracker.DataAccess.AcknowledgementsTrackerContext;Trusted_Connection=yes;");

            string selectAcknowledgement = $"select * from Acknowledgements where id = {id}";
            var acknowledgementsAdapter = new SqlDataAdapter(selectAcknowledgement, myConntection);

            var ds = new DataSet();
            acknowledgementsAdapter.Fill(ds);

            string selectTags = $"select * from TagAcknowledgements where Acknowledgement_Id = {id}";
            var tagsAdapter = new SqlDataAdapter(selectTags, myConntection);

            return ds;
        }
    }
}
