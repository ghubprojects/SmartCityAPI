using SmartCity.Domain.Entities;

namespace SmartCity.Application.DTOs;

public class PlacePhotoDto {
    public int PhotoId { get; set; }
    public string Caption { get; set; } = string.Empty;
    public string FileName { get; set; } = string.Empty;
    public string FilePath { get; set; } = string.Empty;
    public PlacePhotoDto(TPlacePhoto photo) {
        PhotoId = photo.PhotoId;
        Caption = photo.Caption;
        FileName = photo.File.FileName;
        FilePath = photo.File.FilePath;

    }
}