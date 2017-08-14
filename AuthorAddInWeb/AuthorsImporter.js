(function() {
    "use strict";

    var messageBanner;

    Office.initialize = function() {
        $(document).ready(function () {
            var element = document.querySelector(".ms-MessageBanner");
            messageBanner = new fabric.MessageBanner(element);
            $("#clear-document").click(clearDocument);
            $("#search-authors").click(searchAuthors);
        });
    };

    function searchAuthors(e) {
        e.preventDefault();
        $(".authors").empty();
        var authorName = $("#author-name").val();

        if (authorName !== "") {
            var xhr = new XMLHttpRequest();
            xhr.open("GET", "https://localhost:44337/api/authors?name=" + authorName);
            xhr.onload = function (e) {
                var data = JSON.parse(this.response);
           
                if (data.length !== 0) {
                    viewAuthors(data);
                } else {
                    //alert no authors found
                    showNotification("No author found with name " + authorName);
                }
            };
            xhr.onerror = function (e) {
                console.log(e);
            }
            xhr.send();
        }
        else {
            showNotification("Enter an author name");
        }
    }

    function viewAuthors(authors) {
        authors.forEach(function (author, index) {
            var authorSection = $("<div>");
            var authorDetailsSection = $("<div>");
            authorDetailsSection.addClass("author-section-" + author.Id);
            
            var title = $("<h3>");
            title.addClass("ms-fontWeight-semibold ms-fontColor-themePrimary");
            title.text(author.Id + ": " + author.Name + " " + author.LastName);

            var bookTable = $("<table>").addClass("ms-Table");
            var bookTableHead = $("<thead>");
            var bookTableHeadRow = $("<tr>");
            var bookTableBody = $("<tbody>");
            var tableHeaders = ["Id", "Title", "Isbn", "Pages"];

            var insertInWordBtn = $("<button>");
            insertInWordBtn.addClass("ms-Button");
            insertInWordBtn.addClass("ms-Button--primary");

            var insertInWordIconContent = $("<i>");
            insertInWordIconContent.addClass("ms- Icon ms- Icon--Add");

            var insertInWordIcon = $("<span>");
            insertInWordIcon.addClass("ms- Button - icon");
            insertInWordIcon.append(insertInWordIconContent);

            var insertInWordBtnLabel = $("<span>");
            insertInWordBtnLabel.addClass("ms-Button-label");
            insertInWordBtnLabel.text("Insert " + author.Name + " " + author.LastName);
            insertInWordBtn.append(insertInWordBtnLabel);
            insertInWordBtn.click(function (e) {
                insertAuthorSectionInWord(author);
            });

            tableHeaders.forEach(function (title) {
                var tableHead = $("<th>");
                tableHead.text(title);
                bookTableHeadRow.append(tableHead);
            });

            bookTableHead.append(bookTableHeadRow);
            
            author.Books.forEach(function(book, index) {
                var bookRow = $("<tr>");

                tableHeaders.forEach(function(property) {
                    var columnProperty = $("<td>").text(book[property]);
                    bookRow.append(columnProperty);
                });

                bookTableBody.append(bookRow);
            });

            bookTable
                .append(bookTableHead)
                .append(bookTableBody);

            authorDetailsSection
                .append(title)
                .append(bookTable);
            
            authorSection
                .append(authorDetailsSection)
                .append(insertInWordBtn);

            $(".authors").append(authorSection);
        });
    }

    function clearDocument() {
        Word.run(function(context) {
            context.document.body.clear();
        });
    }

    function insertAuthorSectionInWord(author) {
        var authorSection = $(".author-section-" + author.Id);
        
        Word.run(function (context) {
            var body = context.document.body;
            body.insertHtml(authorSection[0].innerHTML, Word.InsertLocation.end);

            return context.sync();
        });
    }

    //$$(Helper function for treating errors, $loc_script_taskpane_home_js_comment34$)$$
    function errorHandler(error) {
        // $$(Always be sure to catch any accumulated errors that bubble up from the Word.run execution., $loc_script_taskpane_home_js_comment35$)$$
        showNotification("Error:", error);
        console.log("Error: " + error);
        if (error instanceof OfficeExtension.Error) {
            console.log("Debug info: " + JSON.stringify(error.debugInfo));
        }
    }

    // Helper function for displaying notifications
    function showNotification(header, content) {
        $("#notification-header").text(header);
        $("#notification-body").text(content);
        messageBanner.showBanner();
    //    messageBanner.toggleExpansion();
    }

})();