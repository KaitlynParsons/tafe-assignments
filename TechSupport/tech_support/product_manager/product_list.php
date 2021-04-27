<?php 
/* 
Author: Kaitlyn Parsons
Student Number: 0105186517
Purpose: product list page
Known bugs:
Date: 22/3/18
 */
include '../view/header.php'; ?>
<main id="main">
    <h1>Product List</h1>
    <section>
        <table>
            <tr>
                <th>Code</th>
                <th>Name</th>
                <th>Version</th>
                <th>Release Date</th>
                <th>&nbsp;</th>
            </tr>
            <?php foreach ($products as $product): ?>
            <tr>
                <td><?php echo $product['productCode'];?></td>
                <td><?php echo $product['name'];?></td>
                <td><?php echo $product['version'];?></td>
                <td><?php echo $product['releaseDate'];?></td>
                <td><form action="." method="post">
                        <input type="hidden" name="action" 
                               value="delete_product">
                        <input type="hidden" name="productID" 
                               value="<?php echo $product['productID'];?>">
                        <input type="submit" value="Delete">
                    </form></td>
            </tr>
            <?php endforeach; ?>
        </table>
        <p><a href=".?action=show_add_form">Add Product</a></p>
    </section>
</main>
<?php include '../view/footer.php'; ?>