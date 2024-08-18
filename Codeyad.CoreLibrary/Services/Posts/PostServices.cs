using Codeyad.CoreLayer.DTOs.Posts;
using Codeyad.CoreLayer.Mapper;
using Codeyad.CoreLayer.Services.FileManager;
using Codeyad.CoreLayer.Utilities;
using Codeyad.DataLayer.Context;
using Codeyad.DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace Codeyad.CoreLayer.Services.Posts;

public class PostServices : IPostServices
{
    private readonly BlogContext _context;
    private readonly IFileManager _fileManager;

    public PostServices(BlogContext context, IFileManager fileManager)
    {
        _context = context;
        _fileManager = fileManager;
    }

    public OperationResult CreatePost(CreatePostDTO command)
    {
        if (command.ImageFile == null)
            return OperationResult.Error("عکس را وارد کنید");
        if(IsSlugExist(command.Slug))
            return OperationResult.Error("Slug تکراری است");

        var post = PostMapper.MapCreateDTOToPost(command);
        try
        {
            post.ImageName = _fileManager.SaveImageAndReturnImageName(command.ImageFile, Directories.PostImage);
        }
        catch
        {
            return OperationResult.Error();
        }
        _context.Posts.Add(post);
        _context.SaveChanges();
       
        return OperationResult.Success();
    }

    public OperationResult DeletePost(int id)
    {
        var post = _context.Posts.FirstOrDefault(p => p.Id == id);
        if (post == null)
        {
            return OperationResult.Error();
        }
        var comments = _context.PostComments.Where(c=> c.PostId == id);
        foreach(var comment in comments)
        {
            _context.PostComments.Remove(comment);
        }
        _context.Posts.Remove(post);
        _context.SaveChanges();
        return OperationResult.Success();
    }

    public OperationResult EditPost(EditPostDTO editPost)
    {
        var post = _context.Posts.FirstOrDefault(m => m.Id == editPost.PostId);
        if (post == null)
            return OperationResult.NotFound();

        if (editPost.Slug!=post.Slug && IsSlugExist(editPost.Slug))
            return OperationResult.Error("Slug تکراری است");

        var oldImage = post.ImageName;

        PostMapper.EditPostDTO(editPost, post);
        if (editPost.ImageFile != null)
        {
            try
            {
                post.ImageName = _fileManager.SaveImageAndReturnImageName(editPost.ImageFile, Directories.PostImage);
            }
            catch
            {
                return OperationResult.Error();
            }
        }
        _context.SaveChanges();

        if (post.ImageName != null)
            _fileManager.DeleteImage(oldImage, Directories.PostImage);

        return OperationResult.Success();
    }

    public List<PostDTO> GetPopularPosts()
    {
        return _context.Posts.Include(p => p.User)
            .OrderByDescending(p=>p.Visit)
            .Take(6)
            .Select(p=>PostMapper.MapToDTO(p))
            .ToList();
    }

    public PostFilterDTO GetPostByFilter(PostFilterParams filterParams)
    {
        var posts = _context.Posts.Include(d=>d.Category).Include(d=>d.SubCategory).OrderBy(p => p.CreationDate).AsQueryable();

        if (!string.IsNullOrEmpty(filterParams.CategorySlug))
            posts = posts.Where(p => p.Category.Slug == filterParams.CategorySlug || p.SubCategory.Slug == filterParams.CategorySlug);
        if (!string.IsNullOrEmpty(filterParams.Title))
            posts = posts.Where(p => p.Title.Contains(filterParams.Title));

        var skip = (filterParams.PageId - 1) * filterParams.Take;

        var model = new PostFilterDTO()
        {
            filterParams = filterParams,
            posts = posts.Skip(skip).Take(filterParams.Take).Select(p => PostMapper.MapToDTO(p)).ToList()
        };
        model.Generatepagination(posts, filterParams.Take, filterParams.PageId);
        return model;
        }

    public PostDTO GetPostById(int postId)
    {
        var post = _context.Posts
            .Include(c=>c.Category)
            .Include(c=>c.SubCategory)
            .FirstOrDefault(m => m.Id == postId);
        if (post == null)
            return null;

        return PostMapper.MapToDTO(post);
    }
    public PostDTO GetPostBySlug(string slug)
    {
        var post = _context.Posts
            .Include(c => c.SubCategory)
            .Include(c => c.Category)
            .Include(c=>c.User)
            .FirstOrDefault(m => m.Slug == slug);
        if (post == null)
            return null;

        return PostMapper.MapToDTO(post);
    }

    public List<PostDTO> GetRealtedPosts(int categoryId, int postId)
    {
        return _context.Posts
            .OrderByDescending(p => p.CreationDate)
            .Where(p => (p.CategoryId == categoryId || p.SubCategoryId == categoryId) && p.Id != postId)
            .Take(6)
            .Select(p=> PostMapper.MapToDTO(p))
            .ToList();
    }

    public void IncreaseVisit(int postId)
    {
        Post post = _context.Posts.First(post => post.Id == postId);
        post.Visit++;
        _context.SaveChanges();
    }

    public bool IsSlugExist(string slug) => _context.Posts.Any(p => p.Slug == slug.ToSlug());
}
