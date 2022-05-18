using System;
using System.Threading.Tasks;
using C1System.Dtos.Media;
using C1System.Media;
using Microsoft.AspNetCore.Mvc;

namespace C1System.Areas.Admin.Controllers;

[Area("Admin")]
public class AdminBlogController : Controller
{
    private readonly IBlogRepository _blogRepository;
    private readonly ITagRepository _tagRepository;
    private readonly IBlogCategoryRepository _blogCategoryRepository;
    private readonly IUploadRepository _uploadRepository;

    public AdminBlogController(IBlogRepository blogRepository, ITagRepository tagRepository,IBlogCategoryRepository blogCategoryRepository, IUploadRepository uploadRepository)
    {
        _blogRepository = blogRepository;
        _tagRepository = tagRepository;
        _blogCategoryRepository = blogCategoryRepository;
        _uploadRepository = uploadRepository;
    }
    
    public async Task<IActionResult> Index()
    {
        var model = await _blogRepository.Get();
        return View(model.Result);
    }
    
    [HttpGet]
    public async Task<IActionResult> AddBlog(Guid id)
    {
        var tags = await _tagRepository.Get();
        ViewBag.Tag = tags.Result;
        
        var blogCats = await _blogCategoryRepository.Get();
        ViewBag.BlogCat = blogCats.Result;
        
        return View();
    }
    
    [HttpPost]
    public async Task<IActionResult> AddBlog(AddBlogDto dto, List<Guid> tagId,List<Guid> blogCatId, List<IFormFile> featureImgFile)
    {
        if (!ModelState.IsValid)
        {
            var tags = await _tagRepository.Get();
            ViewBag.Tag = tags.Result;
            
            var blogCats = await _blogCategoryRepository.Get();
            ViewBag.BlogCat = blogCats.Result;
            
            return View(dto);
        }
        // if (_tagRepository.ExistTag(dto.Title,0))
        // {
        //     ModelState.AddModelError("ErrorTag", "برچسب تکراری است");
        //     return View(dto);
        // }

        var newBlog = await _blogRepository.Add(dto);
        Guid blogId = newBlog.Result.BlogId;
        if (blogId == null)
        {
            TempData["Result"] = "false";
            return RedirectToAction(nameof(Index));
        }

        //tags        
        List<Tag_BlogEntity> addTagBlog = new List<Tag_BlogEntity>();
        
        foreach (var item in tagId)
        {
            addTagBlog.Add(new Tag_BlogEntity()
            {
                TagId = item,
                BlogId = blogId
            });
        }

        bool resTag = _blogRepository.AddBlogsForTag(addTagBlog);
        TempData["Result"] = resTag ? "true" : "false";
        
        //blog categories        
        List<Blog_BlogCategoryEntity> addBlogCat = new List<Blog_BlogCategoryEntity>();
        
        foreach (var item in blogCatId)
        {
            addBlogCat.Add(new Blog_BlogCategoryEntity()
            {
                BlogCategoryId = item,
                BlogId = blogId
            });
        }

        bool resCat = _blogRepository.AddBlogsForCategory(addBlogCat);
        TempData["Result"] = resCat ? "true" : "false";
        
        // upload image
         UploadDto uploadDto = new UploadDto();
         List<IFormFile> fileResult = new List<IFormFile>();

         uploadDto.BlogId = newBlog.Result.BlogId;
        
         foreach (var fileItem in featureImgFile)
         {
             fileResult.Add(fileItem);
         }
         uploadDto.Files = fileResult;
         await _uploadRepository.UploadMedia(uploadDto);
        
        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public async Task<IActionResult> UpdateBlog(Guid id)
    {
        // tags
        var tags = await _tagRepository.Get();
        ViewBag.Tag = tags.Result;
        
        ViewBag.BlogTag = await _blogRepository.ShowBlogsTagForUpdate(id);
        
        // categories
        var blogCats = await _blogCategoryRepository.Get();
        ViewBag.BlogCat = blogCats.Result;
        
        ViewBag.BlogBlogCat = await _blogRepository.ShowBlogsCatForUpdate(id);

        
        var blog = await _blogRepository.GetById(id);
        if (blog.Result == null)
        {
            TempData["NotFoundBlog"] = "true";
            return RedirectToAction(nameof(Index));
        }

        return View(blog.Result);
    }
    
    [HttpPost]
    public async Task<IActionResult> UpdateBlog(UpdateBlogDto dto, List<Guid> tagId)
    {
        if (!ModelState.IsValid)
        {
            var tags = await _tagRepository.Get();
            ViewBag.Tag = tags.Result;
            
            ViewBag.Blog = await _blogRepository.ShowBlogsTagForUpdate(dto.BlogId);

            return View();
        }
        
        //tag
        var updateBlog = _blogRepository.Update(dto.BlogId, dto);
        
        if (updateBlog.Result == null)
        {
            TempData["Result"] = "false";
            return RedirectToAction(nameof(Index));
        }
        
        bool deleteBlog = _blogRepository.DeleteBlogForTag(dto.BlogId);
        if (!deleteBlog)
        {
            TempData["Result"] = "false";
            return RedirectToAction(nameof(Index));
        }
        
        List<Tag_BlogEntity> tagResult = new List<Tag_BlogEntity>();
        foreach (var item in tagId)
        {
            tagResult.Add(new Tag_BlogEntity
            {
                TagId = item,
                BlogId = dto.BlogId,
            });
        }
        bool addBlogForTag= _blogRepository.AddBlogsForTag(tagResult);
        TempData["Result"] = addBlogForTag ? "true" : "false";
        
        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public async Task<IActionResult> DeleteBlog(Guid id)
    {
        var tags = await _tagRepository.Get();
        ViewBag.Tag = tags.Result;
        
        ViewBag.BlogTag = await _blogRepository.ShowBlogsTagForUpdate(id);
        
        var blog = await _blogRepository.GetById(id);
        if (blog.Result == null)
        {
            TempData["NotFoundBlog"] = true;
            return RedirectToAction(nameof(Index));
        }
        return View(blog.Result);
    }
    
    [HttpPost]
    public async Task<IActionResult> DeleteBlogById(Guid id)
    {
        var response = await _blogRepository.Delete(id);
        TempData["ResultDelete"] = response.Status == UtilitiesStatusCodes.Success ? "true" : "false";
        return RedirectToAction(nameof(Index));
    }
}