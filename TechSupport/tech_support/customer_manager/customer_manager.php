<?php
/* 
Author: Kaitlyn Parsons
Student Number: 0105186517
Purpose: Customer Search Page
Known bugs:
Date: 22/3/18
 */
    include('../view/header.php'); 
    //gets all customers to the page
    $customers = searchname();
?>
<main><div id="main">
        <p><?PHP  ?></P>
        <h1>Customer Search</h1>
        <form action="?action=search" method="POST" id="searchform">
            <label>Last Name:</label>
            <input type="text" name="search" placeholder="Search customer...">
            <input type="submit" name="submit" value="Search">
        </form>
    <h1>Results</h1>
    <section>
        <table>
            <tr>
                <th>Name</th>
                <th>Email Address</th>
                <th>City</th>
                <th>&nbsp;</th>
            </tr>
            <?PHP foreach($customers as $customer): ?>
            <tr>
                <td><?PHP echo $customer['firstName']; echo ' ';
                        echo $customer['lastName'];?></td>
                <td><?PHP echo $customer['email']; ?></td>
                <td><?PHP echo $customer['city']; ?></td>
                <td>
                    <form action="?action=select_customer" method="POST" id="select_customer">
                        <input type="hidden" value="select_customer" name="action">
                        <input type="hidden" value="<?PHP echo $customer['customerID']; ?>" name="customerID">
                        <input type="submit" value="Select">
                    </form>
                </td>
            </tr>
             <?PHP endforeach; ?>
        </table>
        
    </section></div>
</main>
<?php
include('../view/footer.php');
?>