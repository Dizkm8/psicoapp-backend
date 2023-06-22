using PsicoAppAPI.Models;
using PsicoAppAPI.Repositories.Interfaces;
using PsicoAppAPI.Services.Interfaces;

namespace PsicoAppAPI.Services;

public class ForumPostService : IForumPostService
{
    private readonly IUnitOfWork _unitOfWork;

    public ForumPostService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }

    public async Task<bool> AddForumPost(ForumPost? post)
    {
        if (post is null) return false;
        return await _unitOfWork.ForumPostRepository.AddForumPostAndSaveChanges(post);
    }
}