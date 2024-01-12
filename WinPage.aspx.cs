/*
* Filename: WinPage.aspx.cs
* Project: Number Guessing Game
* By: Salma Rageh  
* Date: 2023-11-12
* Description: This file and it's functions correspond with the events that happen on the WinPage.aspx page.
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
    public partial class WinPage : System.Web.UI.Page
    {
        /*  Name	:	Page_Load()
	    *	Purpose :	when the page loads, grab the previous viewState
        *	Inputs	:	object			         sender	        	    the oject
        *				EventArgs                e                      
	    *	Outputs	:	NONE
	    *	Returns	:	Nothing
	    */
        protected void Page_Load(object sender, EventArgs e)
        {
            if (PreviousPage != null && PreviousPageViewState != null)
            {
                string userName = (string)PreviousPageViewState["UserName"];
                ViewState["UserName"] = userName;

            }
        }

        /*  Name	:	Button1_Click()
	    *	Purpose :	when the play again button is click, go to the max guess page
        *	Inputs	:	object			         sender	        	    the oject
        *				EventArgs                e                      
	    *	Outputs	:	NONE
	    *	Returns	:	Nothing
	    */
        protected void Button1_Click(object sender, EventArgs e)
        {
            Server.Transfer("MaxGuess.aspx");
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