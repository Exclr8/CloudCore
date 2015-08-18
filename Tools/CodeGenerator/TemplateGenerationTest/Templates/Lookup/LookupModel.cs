

using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CloudCore.Data;

namespace TemplateGenerationTest.Models
{
	public class LookupModel
	{
		[Display(Name="Input Column 1")]
		public System.String InputColumn1 { get; set; }

		[Display(Name="Input Column 2")]
		public System.String InputColumn2 { get; set; }

		[Display(Name="Input Column 12")]
		public System.String InputColumn3 { get; set; }


		public IEnumerable SearchResult { get; set; }
		
		public void Search()
        {
			var db = new CloudCoreDB();

			var result = (from a in db.Cloudcore_User 
                                select new { a.UserId, a.Email });

			SearchResult = result;
		}
	}
}