/*
* Filename: GuessNum.aspx.cs
* Project: Number Guessing Game
* By: Salma Rageh  
* Date: 2023-11-12
* Description: This file and it's functions correspond with the events that happen on the GuessNum.aspx page.
*              They validate the user's guess and update the range.
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
    public partial class GuessNum : System.Web.UI.Page
    {
        /*  Name	:	Page_Load()
	    *	Purpose :	when the page loads, grab the previous viewState, prompt user for guess
        *	Inputs	:	object			         sender	        	    the oject
        *				EventArgs                e                      
	    *	Outputs	:	Initial range for user
	    *	Returns	:	Nothing
	    */
        protected void Page_Load(object sender, EventArgs e)
        {
            if (PreviousPage != null && PreviousPageViewState != null)
            {
                string userName = (string)PreviousPageViewState["UserName"];
                int maxNum = (int)PreviousPageViewState["MaxNum"];
                int minNum = (int)PreviousPageViewState["MinNum"];
                int randomNum = (int)PreviousPageViewState["RandomNum"];
                ViewState["UserName"] = userName;
                ViewState["MaxNum"] = maxNum;
                ViewState["MinNum"] = minNum;
                ViewState["RandomNum"] = randomNum;
                if (IsPostBack == false)
                {
                    guessPrompt.Text = userName + ", guess a number between " + minNum + " and " + maxNum + ":";
                }
                if (IsPostBack == true)
                {
                    ErrorMessage.Text = "";
                }

            }
        }

        /*  Name	:	guessNumButton_Click()
	    *	Purpose :	when the make guess button is clicked, perform validation, update range, check guess
        *	Inputs	:	object			         sender	        	    the oject
        *				EventArgs                e                      
	    *	Outputs	:	Updated range
	    *	Returns	:	Nothing
	    */
        protected void guessNumButton_Click(object sender, EventArgs e)
        {
            if (guessNumEmpty.IsValid && guessNumValid.IsValid)
            {
                int guessNum = Int32.Parse(guessNumBox.Text);
                string userName = (string)ViewState["UserName"];


                if ((guessNum < ((int)ViewState["MinNum"])) || (guessNum > ((int)ViewState["MaxNum"]))) 
                {
                    ErrorMessage.Text = "Your guess is outside the allowable range. Try again!";
                }
                else if (guessNum < ((int)ViewState["RandomNum"]))
                {
                    ViewState["MinNum"] = guessNum;
                    guessPrompt.Text = userName + ", guess a number between " + ViewState["MinNum"].ToString() + " and " + ViewState["MaxNum"].ToString() + ":";
                }
                else if (guessNum > ((int)ViewState["RandomNum"]))
                {
                    ViewState["MaxNum"] = guessNum;
                    guessPrompt.Text = userName + ", guess a number between " + ViewState["MinNum"].ToString() + " and " + ViewState["MaxNum"].ToString() + ":";
                }
                else if (guessNum == ((int)ViewState["RandomNum"]))
                {
                    Server.Transfer("WinPage.aspx");
                }
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