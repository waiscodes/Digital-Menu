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

## Instructions to Install

1. Clone or Download the repository
2. Restore the project and add files (.net and react). In the command line type
    1. dotnet restore
    2. npm i  
3. Make sure to change the connection string before migrating. Change the RestaurantContext file inside the models folder to your own username, password, and root. (I am using a Mac with MAMP)
4. Build project and run

## Instructions to Use the Application 

After Building and running the project, you’ll land on the Login in page. To use the app in admin view.. 
1. To Log in with a pre-populated account type in
    1. Username: Milliways
    2. Password: TrilogyOf5
2. If you want to create your own account,
    1. Click register and fill in the information
3. After registering/logging in, you’ll find yourself on the menu list page for admin view. Scroll
4. Click on a menu item to see more details
    1. If you’re in admin view, you’ll see buttons to delete or edit the menu item
5. Edit Menu item takes you to a form with fields pre-populated with the current data
    1. To update, pick a field and update it. Leave ones you don’t want to update empty
6. At the top of the page you’ll see a navbar with create button
    1. That takes you to a create menu item page
    2. Fill in the fields to create a new menu item
7. To log out, click the logout button on the nabber

To use the app in customer (not logged in) view
1. Type /m/{ username of the restaurant } eg. /m/Milliways 
2. You’ll be taken to the menu page where you can scroll through
3. You can click on the menu item to get more details (edit and delete button don’t show up)

