//Angelo Maragos
//This program simulates a vending machine and problems that can occur with a vending machine.  Try, catch and finally handlers rectifiy exceptional situations
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UML.Assignment9
{
    public class ProductVendingException : System.Exception
    {
        public ProductVendingException(){Console.WriteLine("***ITEM IS STUCK!***");}


    }


    public class ProductOutOfStockException : System.Exception
    {
        public bool check;
        public ProductOutOfStockException() { Console.WriteLine("*** ITEM IS OUT OF STOCK, MAKE ANOTHER SELECTION ***");
        check = true;}
       
    }

    class VendingMachine
    {
        public bool checkOUS = false;
        public bool isOutStock = false;

        public bool stuck()  
        {
            Random rnd = new Random();
            int rnd1 = rnd.Next(1, 10);  //generates a random number between 1 - 10
         //   Console.WriteLine("rnd1 is (from stuck method): {0}", rnd1);
            if (rnd1 == 1)
            {
                return true;  //if random number == 1, item is stuck in vending machine
            }
            else  //else item is not stuck, normal operation

            return false;
        }


        public int shake ()
        {
            Random shk = new Random();
            int shk1 = shk.Next(1, 100);  //Generates random number 1 - 100
           // Console.WriteLine("shk1 is: {0}", shk1);
            pShake = shk1 ;
            if (shk1 <= 40)  //item is freed 40% of the time, if random number == 1 - 40, item is free, else continues to be stuck
            {
                Console.WriteLine("ITEM IS FREE!!!");
            }
            else
                Console.WriteLine("ITEM IS STILL STUCK!!!");
            return shk1;
        }

        public void stock()
        {
        
           //Array list containing "inventory" or "stock" of all items in vending machine
            ArrayList prd = new ArrayList();

            prd.Add("Doritos"); prd.Add("Doritos"); prd.Add("Doritos");
            prd.Add("Cheese Crackers"); prd.Add("Cheese Crackers"); prd.Add("Cheese Crackers"); prd.Add("Cheese Crackers"); prd.Add("Cheese Crackers");
            prd.Add("M&Ms"); prd.Add("M&Ms"); prd.Add("M&Ms"); prd.Add("M&Ms"); prd.Add("M&Ms"); prd.Add("M&Ms"); prd.Add("M&Ms"); prd.Add("M&Ms");
            prd.Add("M&Ms"); prd.Add("M&Ms");
            prd.Add("Trail Mix"); prd.Add("Trail Mix"); prd.Add("Trail Mix"); prd.Add("Trail Mix"); prd.Add("Trail Mix"); prd.Add("Trail Mix");
            prd.Add("SnackWells"); prd.Add("SnackWells"); prd.Add("SnackWells"); prd.Add("SnackWells");

        

            prd1 = prd;

        

        }
      

        //This method accepts a given amount of money that is used for the current transaction.
       public void AcceptMoney(decimal amount)
        {
            
            amt = amount;


            decimal additional = 0m;
            decimal additionalEntered = 0m;
            string usrAmt2;
            if (usrAmt < publicPrice)  //if amount user entered in machine is less than asking price, prompt w/ additional funds msg
            {
                additional = publicPrice - usrAmt;
                Console.WriteLine("Insufficient funds, enter an additional {0}", additional);
                usrAmt2 = Console.ReadLine();
                additionalEntered = Convert.ToDecimal(usrAmt2);

                usrAmt = usrAmt + additionalEntered;

                decimal newUsrAmt = usrAmt;
                if (newUsrAmt < publicPrice)  // if new user amount is still less than asking price, cancel trasaction...refund.
                {
                    Console.WriteLine("Transaction canceled");
                    amtDue = usrAmt + additionalEntered;
                    pubAmtDue = amtDue;

                    amt = newUsrAmt;

                    isTranCanceled = true;
                    prd1.Add(publicPrice);  // replace item in list 
                  //  goto methodEnd;
                }

                amt = usrAmt;
            }



            Console.WriteLine("You entered {0} dollars", amt);

            vendBank += usrAmt;  // vendBank tracks amt of money vending machine has to dispense change


            amtDue = amt - publicPrice;
            vendBank -= amtDue;
            

        }

        // This method returns any leftover money to the customer
        public decimal DispenseChange()
        {
          //  Console.WriteLine("Your change is {0}", amtDue);
            return amtDue;
        }

        // This method accepts the name of a product and, if found, reduces the inventory by one, 
        //keeps the proper amount of money, and dispenses any change that’s due the customer

      //  public float ppu;
      //  public int inventory;                         REMOVE!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
      public void Vend(string product)
        {
            bool isStuck = false;
            decimal price = 0m;
            
    

          Console.WriteLine("*****");
          Console.WriteLine(product);

          Console.WriteLine("*****");

          bool chk = false;

       
          
          if(prd1.Contains(product)) //If product is in array list
          {
              chk = true;
             prd1.Remove(product);  //remove product

        
           
          

          }

          
              else
              {
                 
                  chk = false;  //check, items is not in list
                 
              }

          try
          {
              if (chk == false)
                  throw new ProductOutOfStockException();     //if check == false (item not in list, throw ProductOutOfStockException
          }

          catch(ProductOutOfStockException)
              {
                  checkOUS = true;  //check out of stock set to true
                

                  
              }
          if (checkOUS == true)  //if check Out of Stock set == to true
          {
              isOutStock = true;  //is out of stock
              goto methodEnd;  //go to end of method
          }

          //set pricing for items in vending machine
          if (product == "Doritos")
          {
              price = 1.25m;
          }

          if (product == "Cheese Crackers")
          {
              price = 1.00m;
          }

          if (product == "M&Ms")
          {
              price = 1.00m;
          }

          if (product == "Trail Mix")
          {
              price = 1.50m;
          }

          if (product == "SnackWells")
          {
              price = 0.75m;
          }

          decimal breakBank = 5.00m;  //vending machine does not accept over $5.00
         Console.WriteLine("Enter the appropriate amount of money");
        string usrAmt1 = Console.ReadLine();
        usrAmt = System.Convert.ToDecimal(usrAmt1); 
          
                                                                       

          if (usrAmt > breakBank)
          {
              Console.WriteLine("This Vending Machine does not accept bills larger than $5, money not accepted");
              _breakBank = true;    
              _breakBankAmt = usrAmt;
              goto methodEnd;  //go to method end
          }
    
          publicPrice = price;
       

          this.AcceptMoney(usrAmt);  //accpet money...money entered is less than $5.00

   

          Console.WriteLine("Vending item {0}", product);
          Console.WriteLine("Normally this info is not available to customers...VendBank is {0}", vendBank);
          Console.WriteLine();

 

          string answer = "no";
          try
          {
              isStuck = this.stuck();
              if (isStuck == true)
              {
                  throw new ProductVendingException();  //if item is stuck, throw ProductVendingException
              }

          }

          catch (ProductVendingException)
          {
              Console.WriteLine("Shake to release item? Enter yes or no.");  //prompt user to shake
          }

          finally
          {
              if (isStuck == false)  //if not longer stuck, go to method end
              {
                  goto finallyEnd;
              }

              answer = Console.ReadLine();
              while (answer == "yes" && pShake > 40)  //while answer to shake == yes, and stuck percentage not in 40% range, continue to prompt user to shake machine
              {

                  pShake = this.shake();
                  if (pShake > 40)
                  {
                      Console.WriteLine("Shake vending machine again?");
                      answer = Console.ReadLine();
                  }
                  else
                      answer = "no";  //if no, item remains stuck, change is given to customer

              }
          finallyEnd:
              Console.WriteLine();
              
          }




          methodEnd:
          return;



        

        }

      public bool isTranCanceled = false;
        public decimal pubAmtDue =0m;
        private decimal amt;
        private decimal usrAmt = 0m;
       
        private decimal amtDue = 0m;
        decimal vendBank = 10m; // vendBank in vending machine starts off w/ $10
        public ArrayList prd1 = new ArrayList();
        private int pShake = 41;
        private decimal publicPrice = 0m;
    
        public bool _breakBank = false;
        public decimal _breakBankAmt = 0m;


    }
    class Program
    {
        static void Main(string[] args)
        {
           decimal a = 0m;
           string snack = null;
           int value1 = 0;
            
            VendingMachine product = new VendingMachine();
          //create object from vending machine class
            product.stock();
      

       //  a = product.DispenseChange();
            int x = 0;

        jumpOver:

            x++;
            product.checkOUS = false;


            while (true)  //loop continues until user enters 0
            {
            startOver:

                Console.WriteLine("What snack do you want?");
                Console.WriteLine();
                Console.WriteLine("Enter 1 for Doritos ($1.25)");
                Console.WriteLine("Enter 2 for Cheese Crackers ($1.00)");
                Console.WriteLine("Enter 3 for M&Ms ($1.00)");
                Console.WriteLine("Enter 4 for Trail Mix ($1.50)");
                Console.WriteLine("Enter 5 for SnackWells ($0.75)");
                Console.WriteLine("Enter 0 to cancel transaction/exit Vending Machine");

                

                string value = Console.ReadLine();
                value1 = Convert.ToInt32(value);  //read what item user wants


                switch (value1)
                {
                    case 1:
                        snack = "Doritos";
                        break;
                    case 2:
                        snack = "Cheese Crackers";
                        break;
                    case 3:
                        snack = "M&Ms";
                        break;
                    case 4:
                        snack = "Trail Mix";
                        break;
                    case 5:
                        snack = "SnackWells";
                        break;
                    case 0:
                        goto jumpEnd;  //jump to end of main
                }


                product.Vend(snack);  //passing snack to Vend method

  
                if (product._breakBank == true)  //if money entered is over $5.00... broke the bank in vending machine, money not accepted
                {

                    Console.WriteLine("Your change is {0}", product._breakBankAmt);
                    product._breakBank = false;
                    goto startOver;
                }
               
                
                if(product.checkOUS == true)  //if product is out of stock, prompt customer again for new entry
                {
                    goto jumpOver;
                }

                if (product.isTranCanceled == true)//transaction canceled
                {

                }

                a = product.DispenseChange();
                Console.WriteLine("Your change is {0}", a);

          
            }

            jumpEnd:
            Console.WriteLine("Press enter to exit Vending Machine");

         
         Console.ReadLine();

            
        }
    }
}
