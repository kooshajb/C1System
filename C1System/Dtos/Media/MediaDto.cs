﻿namespace C1System.Dtos.Media;

public class MediaDto {
    public string Id { get; set; }
    public FileTypes Type { get; set; }
    public string UseCase { get; set; }
    public string? Link { get; set; }
}