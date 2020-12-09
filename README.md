# Capstone Project: The Restaurant at the End of the Universe

by Birm Wais - Don't Panic

Trello Board: https://trello.com/b/EcSARmmm/dont-panic

## Problem

I’m always flustered and end up ordering the most familiar thing on the menu because I often don’t recognize names of menu items. I always find it easier to choose when the menu items have pictures, and I’m always more willing to get out of my comfort zone to choose different types of foods when they do.

## Solution

A web app menu that includes pictures of menu items as well as details of the menu items when clicked on.

### Users

- Customer (Guest)
- Administrator (Account)
  - Sign In

#### Core Features (In Scope)

- Browse List of Menu Items (Customer)
  - Ability to filter by Diet, Allergy, Religious restrictions
  - Broken up into categories (Starter, Main Course, and Dessert)
  - Individual Details View
    - Includes Gallery
    - Information on Ingredients
    - Fat, Protein, Calories etc
    - Average wait times
    - Diet, Allergy, Religious restrictions compliance
- Administrator View
  - Create Menu Item
    - Input fields for text and to upload images
    - Update Menu Items
    - Delete Existing Menu Items

#### Out of Scope (for the current project timeline)

- Comment on individual menu items
- Star Ratings on menu items
  - Ability to sort by rating
- Scheduled specials from the restaurant depending on the day
- Profile of the Restaurant

## Citation Summary

- Email Regex: https://emailregex.com/
- Image Upload and Delete using Iwebhost file stream: https://github.com/CodAffection/React-Asp.Net-Core-API---Image-Upload-Retrieve-Update-and-Delete-/blob/master/EmployeeRegisterAPI/EmployeeRegisterAPI/Controllers/EmployeeController.cs
- Escape: https://docs.microsoft.com/en-us/dotnet/api/system.text.regularexpressions.regex.escape?view=net-5.0
- FormData: https://bezkoder.com/react-file-upload-axios/
- Useparams: https://reacttraining.com/blog/react-router-v5-1/

## Testing Instructions
Login 
- Length limitation on input
- Invalid username returns: “There is no account under this email”
- Invalid password returns: “Password is incorrect”

Register
- Length limitations on input
    - If postman were used to put extra length: “{input} cannot exceed {max length in database} Characters"
- If username is already taken: “Restaurant username is taken”
- If email already taken: “An account by that email already exists”
- If fields are empty: “{field name} cannot be empty”
- If there’s a special character in username: “username cannot contain special characters”
- If there’s a space in username: “username cannot contain a space”

Create
- Length limitation on inputs
- If length is surpassed: “{input} cannot exceed {max length}
- Required html validator 
- If field is left empty: “{field name} cannot be empty”

Edit
- Length limitation on inputs
- If length is surpassed: “{input} cannot exceed {max length}
- If field is left empty: “{field name} cannot be empty” 

Delete
- Delete button deletes item if it exists
- On postman, Menu Item doesn’t not exist
