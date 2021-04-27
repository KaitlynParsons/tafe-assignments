<?php 
/* 
Author: Kaitlyn Parsons
Student Number: 0105186517
Purpose: Select Customer page
Known bugs:
Date: 22/3/18
 */
include '../view/header.php'; ?>
<main id="main">
    <h1>Customer Search</h1>
    <section>
        <form action="index.php" method="post">
        <label>Last Name:</label>
        <input type="text" name="customerLast" 
               placeholder="Search customers...">
        <input type='hidden' name='action' value='search_customer'>
        <input type="submit" name="submit"value="Search">
        </form>
    <h1>Results</h1>
        <table>
            <tr>
                <th>Name</th>
                <th>Email Address</th>
                <th>City</th>
                <th>&nbsp;</th>
            </tr>
             <?php foreach ($customers as $customer): ?>
            <tr>
                <td><?php echo $customer['firstName'];?>
                    <?php echo $customer['lastName'];?></td>
                <td><?php echo $customer['email'];?></td>
                <td><?php echo $customer['city'];?></td>
                <td><form action="." method="post">
                        <input type="hidden" name="action" 
                               value="show_update_form">
                        <input type="hidden" name="customerID" 
                               value="<?php echo $customer['customerID'];?>">
                        <input type="submit" value="Select">
                    </form></td>
            </tr>
            <?php endforeach; ?>
        </table>
    </section>
</main>
<?php include '../view/footer.php'; ?>

