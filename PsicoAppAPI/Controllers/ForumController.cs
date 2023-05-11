﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PsicoAppAPI.Models;
using PsicoAppAPI.Data;

namespace PsicoAppAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ForumController : ControllerBase
{
    private readonly DataContext _context;

    public ForumController(DataContext context) => _context = context;

    /// <summary>
    /// Add a forum post in database context 
    /// </summary>
    /// <param name="post">Post to add</param>
    /// <returns>Post saved</returns>
    [HttpPost]
    public IActionResult AddForumPost(ForumPost post)
    {
        _context.ForumPosts.Add(post);
        _context.SaveChanges();
        return Ok(post);
    }

    /// <summary>
    /// Get a forum post by its id in database context
    /// </summary>
    /// <param name="id">post id</param>
    /// <returns>Operation result</returns>
    [HttpGet("{id}")]
    public IActionResult GetForumPost(int id)
    {
        var post = _context.ForumPosts.FirstOrDefault(e => e.Id == id);
        if (post == default(ForumPost))
        {
            return NotFound();
        }
        return Ok(post);
    }

    /// <summary>
    /// Deletes a forum post given its id
    /// </summary>
    /// <param name="id">post id</param>
    /// <returns>Operation result</returns>
    [HttpDelete("{id}")]
    public IActionResult DeleteForumPost(int id)
    {
        var post = _context.ForumPosts.FirstOrDefault(e => e.Id == id);
        if (post == default(ForumPost))
        {
            return NotFound();
        }
        _context.ForumPosts.Remove(post);
        
        var comments = _context.Comments
            .Where(e => e.PostId == id)
            .ToList();
        _context.Comments.RemoveRange(comments);
        
        _context.SaveChanges();
        return Ok();
    }
    
    /// <summary>
    /// Change forum post status to approved or disapproved by their id
    /// </summary>
    /// <param name="id">post id</param>
    /// <param name="isApproved">approved status</param>
    /// <returns>Task</returns>
    [HttpPut("{id}, {isApproved}")]
    public async Task<IActionResult> ChangeForumPostStatus(int id, bool isApproved)
    {
        var post = _context.Find<ForumPost>(id);
        if (post == null)
        {
            return NotFound();
        }
        post.IsApproved = isApproved;
        
        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            throw;
        }
        return NoContent();
    }

    /// <summary>
    /// Get all forum posts in database context
    /// </summary>
    /// <returns>All posts collected</returns>
    [HttpGet]
    public IActionResult GetForumPosts()
    {
        var posts = _context.ForumPosts.ToList();
        return Ok(posts);
    }

    /// <summary>
    /// Get all forum posts that have a given tag in database context
    /// </summary>
    /// <param name="tag">tag to search</param>
    /// <returns>All posts collected</returns>
    [HttpGet("tag/{tag}")]
    public IActionResult GetForumPostsByTag(string tag)
    {
        var posts = _context.ForumPosts
            .Where(e => e.Tag == tag)
            .ToList();
        return Ok(posts);
    }
}