using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PsicoAppAPI.DTOs;
using PsicoAppAPI.DTOs.UpdateProfileInformation;
using PsicoAppAPI.Services.Interfaces;

namespace PsicoAppAPI.Controllers
{
    public class UsersController : BaseApiController
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        /// <summary>
        /// Get the user's profile information extracting Claims included on the JWT token.
        /// </summary>
        /// <returns>
        /// If the JWT was not provided or is invalid, return a Status 401.
        /// If the JWT have error extracting the Claims, return a Status 404.
        /// If the user's profile information is not found, return a Status 404.
        /// If the user's profile information is found, return a Status 200 with the user's profile information.
        /// </returns>
        [Authorize]
        [HttpGet("profile-information")]
        public async Task<ActionResult> GetProfileInformation()
        {
            var profileInformationDto = await _userService.GetUserProfileInformation();
            if (profileInformationDto == null) return Unauthorized("JWT not provided or invalid");
            return Ok(profileInformationDto);
        }

        /// <summary>
        /// Update the user's profile information extracting Claims included on the JWT token.
        /// </summary>
        /// <param name="updateProfileInformationDto">
        /// Name: User's name, must be not null and have at least 2 characters
        /// FirstLastName: User's first last name, must be not null and have at least 2 characters
        /// SecondLastName: User's second last name, must be not null and have at least 2 characters
        /// Email: User's email, must be not null, have a valid email format and be unique
        /// Gender: User's gender, must be not null or empty
        /// Phone: User's phone, must be not null and have 8 digits
        /// </param>
        /// <returns>
        /// If the ModelState have errors based on params requeriments, return a Status 400 with the errors.
        /// If the Email exists in other user, return a Status 400 with the error.
        /// If the user cannot be updated in the database, return a Status 500 with a generic error.
        /// If the user is added to the database, return a Status 200 with the user's data shaped
        ///  as UpdateProfileInformationDto.
        /// </returns>
        [Authorize]
        [HttpPut("profile-information")]
        public async Task<ActionResult> UpdateProfileInformation([FromBody] UpdateProfileInformationDto updateProfileInformationDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            // Needs to validate if exists In Different users to avoid
            // rejecting the update if the user doesn't change the email
            var existsEmail = await _userService.ExistsEmailInOtherUser(updateProfileInformationDto.Email);
            if (existsEmail) return BadRequest(new { error = "Email already exists" });

            var result = await _userService.UpdateProfileInformation(updateProfileInformationDto);
            if (result is null) return StatusCode(StatusCodes.Status500InternalServerError,
                new { error = "Internal error updating User" });
            return Ok(result);
        }

        /// <summary>
        /// Update the user's password extracting Claims included on the JWT token.
        /// </summary>
        /// <param name="updatePasswordDto">
        /// CurrentPassword: User's current password, must be not null or empty
        /// NewPassword: User's new password, must be not null or empty and have a length between 10 and 15 characters
        /// ConfirmNewPassword: User's new password confirmation, 
        /// must be not null or empty, have a length between 10 and 15 characters
        /// and match with the NewPassword param
        /// </param>
        /// <returns>
        /// If the ModelState have errors based on params requeriments, return a Status 400 with the errors.
        /// If the user is not found based on JWT, return a Status 400 with the error.
        /// If the currentPassword provided is incorrect, return a Status 400 with the error.
        /// If something went wrong updating the password, return a Status 500 with generic error.
        /// If the password is updated successfully, return a Status 200 with no info.«
        /// </returns>
        [Authorize]
        [HttpPut("update-password")]
        public async Task<ActionResult> UpdatePassword([FromBody] UpdatePasswordDto updatePasswordDto)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors);
                return BadRequest(new { errors });
            }
            // Check if user exists based on the JWT provided
            var existUser = await _userService.ExistsUserByToken();
            if (!existUser) return BadRequest(new { error = "User not found" });
            // Check if the old password is correct
            var isPasswordCorrect = await _userService.CheckUsersPasswordUsingToken(updatePasswordDto.CurrentPassword);
            if (!isPasswordCorrect) return BadRequest(new { error = "Current password is incorrect" });
            // Tries to update the password
            var result = await _userService.UpdateUserPassword(updatePasswordDto.NewPassword);
            if (!result) return StatusCode(StatusCodes.Status500InternalServerError,
                new { error = "Internal error updating User" });
            // No info is returned if the password was updated successfully
            // because the user is logged out after the password is updated
            return Ok();
        }
    }

}