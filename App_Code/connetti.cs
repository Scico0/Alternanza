using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.Data;
namespace Alternanza
{
    class connetti
    {
    private String coll;
    private OleDbConnection conn;
    private OleDbCommand comm;
    public DataTable tbl; //tabella risultati
    private OleDbDataAdapter adtpro;

	public connetti()
	{
        coll = "provider=Microsoft.ACE.OLEDB.12.0;Data Source=alternanza.accdb";

        conn = new OleDbConnection(coll);
		//
		// TODO: aggiungere qui la logica del costruttore
		//
	}
    private void apri()
    {
        conn.Open();
    }
    private void chiudi()
    {
        conn.Close();
    }

    public void eseguidml(String sql) // insert, update, delete
    {
        apri();
        comm = new OleDbCommand(sql, conn);
        comm.ExecuteNonQuery();
        chiudi();
    }

    public void eseguiquery(String sql) // select
    {
        apri();
        tbl = new DataTable();
        adtpro = new OleDbDataAdapter(sql, conn);
        adtpro.Fill(tbl);
        chiudi();
    }
    }
}
