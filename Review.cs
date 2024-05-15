[HttpPost("delete/{id}")]
public IActionResult Delete(uint id) // change void to IActionResult for returning status code
{
    var user = _context.Users.FirstOrDefault(user => user.Id == id);
    // check if user with id exists
    if (user != null)
    {
        _context.Users.Remove(user);
        _context.SaveChanges();

        Debug.WriteLine($"User deleted with login {user.login}");
    }
    else
    {
        // log that user with id not found
        Debug.WriteLine($"User with id {id} not found");
    }

    return Ok();
}