CREATE PROCEDURE dbo.GetArtistDetailsFromArtistID
	@ArtistId INT
AS
BEGIN

	SELECT
		*
	FROM
		Artist
	WHERE
		Artist.artistID = @ArtistId

END