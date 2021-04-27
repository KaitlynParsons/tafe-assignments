<?php 
/* 
Author: Kaitlyn Parsons
Student Number: 0105186517
Purpose: add products page
Known bugs:
Date: 22/3/18
 */
include '../view/header.php'; ?>
<main id='main'>
    <h1>Add Product</h1>
    <form action="index.php" method="post">
        <input type="hidden" name="action" value="add_product">
        
        <label id='alignedlabel'>Code:</label>
        <input type="text" name="productCode" />
        <br>

        <label id='alignedlabel'>Name:</label>
        <input type="text" name="productName" />
        <br>

        <label id='alignedlabel'>Version:</label>
        <input type="text" name="version" />
        <br>

        <label id='alignedlabel'>Release Date:</label>
        <input type="text" name="releaseDate" />
        <label>Use yyyy-mm-dd format</label>
        <br>
        
        <label id='alignedlabel'>&nbsp;</label>
        <input type="submit" value="Add Product" />
        
        <br>
    </form>
    <p><a href="index.php?action=product_list">View Product List</a></p>
</main>

<?php include '../view/footer.php'; ?>