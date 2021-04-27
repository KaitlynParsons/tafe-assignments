<?php 
/* 
Author: Kaitlyn Parsons
Student Number: 0105186517
Purpose: View/Update Customer page
Known bugs:
Date: 22/3/18
 */
include '../view/header.php'; ?>
<main id='main'>
    <h1>View/Update Customer</h1>
    <form action='index.php' method='post'>
        <input type='hidden' name='action' value='update_customer'>
        <?php foreach ($customers as $customer): ?>
        <label id='alignedlabel'>First Name:</label>
        <input type="text" name="firstName" id="alignedinput"
               value="<?php echo htmlspecialchars($customer['firstName']);?>"/>
        <br>

        <label id='alignedlabel'>Last Name:</label>
        <input type="text" name="lastName" id="alignedinput"
               value="<?php echo htmlspecialchars($customer['lastName']);?>""/>
        <br>
        
        <label id='alignedlabel'>Address:</label>
        <input type="text" name="address" id="alignedinputtext"
               value="<?php echo htmlspecialchars($customer['address']);?>"/>
        <br>
        
        <label id='alignedlabel'>City:</label>
        <input type="text" name="city" id="alignedinput"
               value="<?php echo htmlspecialchars($customer['city']);?>"/>
        <br>
        
        <label id='alignedlabel'>State:</label>
        <input type="text" name="state" id="alignedinput"
               value="<?php echo htmlspecialchars($customer['state']);?>"/>
        <br>
        
        <label id='alignedlabel'>Postal Code:</label>
        <input type="text" name="postalCode" id="alignedinput"
               value="<?php echo htmlspecialchars($customer['postalCode']);?>"/>
        <br>
        
        <label id='alignedlabel'>Country Code:</label>
        <input type="text" name="countryCode" id="alignedinput"
               value="<?php echo htmlspecialchars($customer['countryCode']);?>"/>
        <br>

        <label id='alignedlabel'>Email:</label>
        <input type="text" name="email" id="alignedinputtext"
               value="<?php echo htmlspecialchars($customer['email']);?>"/>
        <br>

        <label id='alignedlabel'>Phone:</label>
        <input type="text" name="phone" id="alignedinput"
               value="<?php echo htmlspecialchars($customer['phone']);?>"/>
        <br>
        
        <label id='alignedlabel'>Password:</label>
        <input type="text" name="password" id="alignedinput"
               value="<?php echo htmlspecialchars($customer['password']);?>"/>
        <br>
        
        <label id='alignedlabel'>&nbsp;</label>
        <input type="submit" value="Update Customer" />
        <br>
        <?php endforeach; ?>
        <br>
    </form>
    <p><a href="index.php?action=select_customer">Search Customers</a></p>
</main>

<?php include '../view/footer.php'; ?>

