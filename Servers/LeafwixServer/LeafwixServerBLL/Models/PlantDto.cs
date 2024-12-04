namespace LeafwixServerBLL.Models
{
    /* Request Models  */

    public record AddPlantRequest
    (
        string Name,
        double Age,
        Guid PlantSpeciesId,
        Guid UserId
    );

    public record UpdatePlantRequest
    (
        Guid Id,
        string Name,
        double Age,
        int Health,
        Guid PlantSpeciesId,
        Guid UserId
    );

    /* Response Models */
    public record PlantResponse
    (
        Guid Id,
        string Name,
        double Age,
        string imgPath,
        int Health

    );
    public record PlantListResponse
    (
        Guid Id,
        string Name,
        double Age,
        string imgPath,
        string Type,
        int Health
    );
}
