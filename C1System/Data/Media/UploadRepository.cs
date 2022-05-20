using C1System.Dtos.Media;
using Microsoft.EntityFrameworkCore;

namespace C1System.Media;
public interface IUploadRepository
{
    Task<GenericResponse> UploadMedia(UploadDto model);
    Task<GenericResponse> DeleteMedia(Guid id);
}

public class UploadRepository : IUploadRepository
{
    private readonly IWebHostEnvironment _env;
    private readonly IMediaRepository _mediaRepository;
    private readonly C1SystemContext _context;

    public UploadRepository(C1SystemContext context, IWebHostEnvironment env, IMediaRepository mediaRepository)
    {
        _env = env;
        _mediaRepository = mediaRepository;
        _context = context;
    }

    public async Task<GenericResponse> UploadMedia(UploadDto model)
    {
        if (model.Files.Count < 1)
        {
            return new GenericResponse(UtilitiesStatusCodes.BadRequest, "File not uploaded");
        }
        List<Guid>? ids = new List<Guid>();
        foreach (IFormFile file in model.Files)
        {
            FileTypes fileType = FileTypes.Image;
            
            if (file.ContentType.Contains("svg"))
            {
                fileType = FileTypes.Svg;
            }

            if (file.ContentType.Contains("video"))
            {
                fileType = FileTypes.Video;
            }

            if (file.ContentType.Contains("pdf"))
            {
                fileType = FileTypes.Pdf;
            }

            if (file.ContentType.Contains("Voice"))
            {
                fileType = FileTypes.Voice;
            }

            if (file.ContentType.Contains("Gif"))
            {
                fileType = FileTypes.Gif;
            }

            string folder = "";
            // if (model.UserId != null)
            // {
            //     folder = "Users";
            //     List<MediaEntity> userMedia =
            //         _context.Set<MediaEntity>()
            //             // .Where(x => x.UserId == model.UserId)
            //             .ToList();
            //     if (userMedia.Count > 0)
            //     {
            //         _context.Set<MediaEntity>().RemoveRange(userMedia);
            //         _context.SaveChanges();
            //     }
            // }

            if (model.PortfolioId != null)
            {
                if (file.Name == "galleryFile")
                {
                    folder = "Portfolios/Gallery";
                }
                else if (file.Name == "featureImgFile")
                {
                    folder = "Portfolios/FeatureImg";
                }
                else if (file.Name == "companyLogoFile")
                {
                    folder = "Portfolios/CompanyLogo";
                }
                List<MediaEntity> portfolioMedia =
                    _context.Set<MediaEntity>().ToList();
            }
            
            if (model.CategoryId != null)
            {
                if (file.Name == "iconImageFile")
                {
                    folder = "Categories/IconCategory";
                }
                else if (file.Name == "videoIntroFile")
                {
                    folder = "Categories/VideoIntro";
                }
                List<MediaEntity> categoryMedia =
                    _context.Set<MediaEntity>().ToList();
            }
            
            if (model.TechnologyId != null)
            {
                folder = "Technologies";
                List<MediaEntity> technologyMedia =
                    _context.Set<MediaEntity>().ToList();
            }
            
            if (model.PodcastId != null)
            {
                if (file.Name == "audioFile")
                {
                    folder = "Podcasts/Audios";
                }
                else if (file.Name == "featureImgFile")
                {
                    folder = "Podcasts/FeatureImg";
                }
                List<MediaEntity> podcastMedia =
                    _context.Set<MediaEntity>().ToList();
            }
            
            if (model.BlogId != null)
            {
                folder = "Blogs";
                List<MediaEntity> blogMedia =
                    _context.Set<MediaEntity>().ToList();
            }
            
            if (model.CustomerSuccessId != null)
            {
                folder = "CustomerSuccess";
                List<MediaEntity> customerSuccessMedia =
                    _context.Set<MediaEntity>().ToList();
            }
            
            if (model.ProjectId != null)
            {
                folder = "Projects";
                List<MediaEntity> projectMedia =
                    _context.Set<MediaEntity>().ToList();
            }

            string name = _mediaRepository.GetFileName(Guid.NewGuid(), Path.GetExtension(file.FileName));
            string url = _mediaRepository.GetFileUrl(name, folder: folder);
            
            if(model.PortfolioId != null){
                MediaEntity media = new MediaEntity
                {
                    FileName = url,
                    FileType = fileType,
                    PortfolioId = model.PortfolioId,
                };
                
                await _context.Set<MediaEntity>().AddAsync(media);
                await _context.SaveChangesAsync();
                ids.Add(media.Id);
                _mediaRepository.SaveMedia(file, name, folder);
            }
            
            if(model.CategoryId != null){
                MediaEntity media = new MediaEntity
                {
                    FileName = url,
                    FileType = fileType,
                    CategoryId = model.CategoryId,
                };
                
                await _context.Set<MediaEntity>().AddAsync(media);
                await _context.SaveChangesAsync();
                ids.Add(media.Id);
                _mediaRepository.SaveMedia(file, name, folder);
            }
            
            if(model.TechnologyId != null){
                MediaEntity media = new MediaEntity
                {
                    FileName = url,
                    FileType = fileType,
                    TechnologyId = model.TechnologyId,
                };
                
                await _context.Set<MediaEntity>().AddAsync(media);
                await _context.SaveChangesAsync();
                ids.Add(media.Id);
                _mediaRepository.SaveMedia(file, name, folder);
            }
            
            if(model.PodcastId != null){
                MediaEntity media = new MediaEntity
                {
                    FileName = url,
                    FileType = fileType,
                    PodcastId = model.PodcastId,
                };
                
                await _context.Set<MediaEntity>().AddAsync(media);
                await _context.SaveChangesAsync();
                ids.Add(media.Id);
                _mediaRepository.SaveMedia(file, name, folder);
            }
            
            if(model.BlogId != null){
                MediaEntity media = new MediaEntity
                {
               
                    FileName = url,
                    FileType = fileType,
                    BlogId = model.BlogId,
                };
                
                await _context.Set<MediaEntity>().AddAsync(media);
                await _context.SaveChangesAsync();
                ids.Add(media.Id);
                _mediaRepository.SaveMedia(file, name, folder);
            }
            
            if(model.CustomerSuccessId != null){
                MediaEntity media = new MediaEntity
                {
               
                    FileName = url,
                    FileType = fileType,
                    CustomerSuccessId = model.CustomerSuccessId,
                };
                
                await _context.Set<MediaEntity>().AddAsync(media);
                await _context.SaveChangesAsync();
                ids.Add(media.Id);
                _mediaRepository.SaveMedia(file, name, folder);
            }
            
            if(model.ProjectId != null){
                MediaEntity media = new MediaEntity
                {
                    FileName = url,
                    FileType = fileType,
                    ProjectId = model.ProjectId,
                };
                
                await _context.Set<MediaEntity>().AddAsync(media);
                await _context.SaveChangesAsync();
                ids.Add(media.Id);
                _mediaRepository.SaveMedia(file, name, folder);
            }
        }

        return new GenericResponse(UtilitiesStatusCodes.Success, "File uploaded", ids);
    }

    public async Task<GenericResponse> DeleteMedia(Guid id)
    {
        MediaEntity? media = await _context.Set<MediaEntity>().FirstOrDefaultAsync(x => x.Id == id);
        if (media == null)
        {
            return new GenericResponse(UtilitiesStatusCodes.NotFound, "File not Found");
        }

        _context.Set<MediaEntity>().Remove(media);
        await _context.SaveChangesAsync();

        return new GenericResponse(UtilitiesStatusCodes.Success, "Success");
    }
}