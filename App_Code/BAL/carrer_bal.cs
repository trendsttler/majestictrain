using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for carrer_bal
/// </summary>
public class carrer_bal
{
	public carrer_bal()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public virtual int insertcarrerdata(carrer_prp prp)
    {
        carrer_dal dal = new carrer_dal();
        return dal.insertcarrerdata(prp);


    }
}