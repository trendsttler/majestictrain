using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <
/// >
/// Summary description for query_bal
/// </summary>
public class query_bal
{
	public query_bal()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public virtual int insert_query(query_prp prp)
    {
        query_dal dal = new query_dal();

        return dal.insert_query(prp);

    }
}