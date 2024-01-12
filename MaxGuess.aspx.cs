/*
* Filename: MaxGuess.aspx.cs
* Project: Number Guessing Game
* By: Salma Rageh  
* Date: 2023-11-12
* Description: This file and it's functions correspond with the events that happen on the MaxGuess.aspx page.
*/

using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace A04
{
    public partial class MaxGuess : System.Web.UI.Page
    {
        /*  Name	:	Page_Load()
	    *	Purpose :	when the page loads, grab the previous viewState, prompt user for max guess
        *	Inputs	:	object			         sender	        	    the oject
        *				EventArgs                e                      
	    *	Outputs	:	prompt for user to enter max guess number
	    *	Returns	:	Nothing
	    */
        protected void Page_Load(object sender, EventArgs e)
        {
            if (PreviousPage != null && PreviousPageViewState != null)
            {
                string userName = (string)PreviousPageViewState["UserName"];
                ViewState["UserName"] = userName;
                maxGuessPrompt.Text = userName + ", enter the maximum guess number: ";
            }
        }

        /*  Name	:	maxGuessButton_Click()
	    *	Purpose :	when the submit button is clicked, perform validation, create viewState variables
        *	Inputs	:	object			         sender	        	    the oject
        *				EventArgs                e                      
	    *	Outputs	:	None
	    *	Returns	:	Nothing
	    */
        protected void maxGuessButton_Click(object sender, EventArgs e)
        {
            if (maxGuessEmptyValid.IsValid && maxGuessNumValid.IsValid && maxGuessRange.IsValid)
            {
                int maxNum = Int32.Parse(maxGuessBox.Text);
                ViewState["MaxNum"] = maxNum;
                ViewState["MinNum"] = 1;
                Random random = new Random();
                ViewState["RandomNum"] = random.Next(2, maxNum + 1);

                Server.Transfer("GuessNum.aspx");
            }
        }

        /*  Name	:	PreviousPageViewState
	    *	Purpose :	get the viewState
        *	Inputs	:	none                     
	    *	Outputs	:	none
	    *	Returns	:	Previous pages view state
	    */
        private StateBag PreviousPageViewState
        {
            get
            {
                StateBag returnValue = null;
                if (Page.PreviousPage != null)
                {
                    Object objPreviousPage = (Object)PreviousPage;
                    MethodInfo objMethod = objPreviousPage.GetType().GetMethod("ReturnViewState");      
                    return (StateBag)objMethod.Invoke(objPreviousPage, null);
                }
                return returnValue;
            }
        }

        /*  Name	:	ReturnViewState()
	    *	Purpose :	to return the view state to use in other pages
        *	Inputs	:	None                    
	    *	Outputs	:	None
	    *	Returns	:	The view state
	    */
        public StateBag ReturnViewState()
        {
            return ViewState;
        }
    }
}