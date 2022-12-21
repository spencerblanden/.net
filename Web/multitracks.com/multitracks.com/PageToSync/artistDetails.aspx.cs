using System;
using System.Data;
using System.Security.Cryptography.X509Certificates;
using System.Web.UI.WebControls;
using DataAccess;

public partial class artistDetails : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        var artistId = 5;

        ArtistTitle(artistId);
        ArtistSongs(artistId);
        ArtistAlbum(artistId);

    }

    private void ArtistTitle(int artistId)
    {
        var sql = new SQL();


        sql.Parameters.Add("@ArtistId", artistId);
        var details = sql.ExecuteStoredProcedureDT("GetArtistDetailsByArtistID");


        var name = details.Rows[0]["title"].ToString();
        var imageURL = details.Rows[0]["imageUrl"].ToString();
        var heroImageURL = details.Rows[0]["heroUrl"].ToString();


        artistName.Text = name;
        /*        artistAlbumName.Text = name;
        */        //imageMainUrl.Text = imageURL;


        hero.ImageUrl = heroImageURL;
        image.ImageUrl = imageURL;



    }

    private void ArtistSongs(int artistId)
    {
        var sql = new SQL();

        sql.Parameters.Add("@ArtistId", artistId);
        var songs = sql.ExecuteStoredProcedureDT("GetSongsByArtistId");

        repeaterSongs.DataSource = songs;
        repeaterSongs.DataBind();
    }

    private void ArtistAlbum(int artistId)
    {
        var sql = new SQL();

        sql.Parameters.Add("@ArtistId", artistId);
        DataTable albums = sql.ExecuteStoredProcedureDT("GetAlbumsByArtistId");



        repeaterAlbums.DataSource = albums;
        repeaterAlbums.DataBind();
    }
}