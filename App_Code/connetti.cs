using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.OleDb;
/// <summary>
/// Descrizione di riepilogo per connetti
/// </summary>
public class connetti
{

    private String coll;
    private OleDbConnection conn;
    private OleDbCommand comm;
    public DataTable tbl;
    private OleDbDataAdapter adtpro;

    public connetti()
    {
        coll = "provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|alternanza.accdb";

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

    public void eseguidml(String sql)
    {
        apri();
        comm = new OleDbCommand(sql, conn);
        comm.ExecuteNonQuery();
        chiudi();
    }
    public void eseguiquery(String sql)
    {
        apri();
        tbl = new DataTable();
        adtpro = new OleDbDataAdapter(sql, conn);
        adtpro.Fill(tbl);
        chiudi();
    }
}