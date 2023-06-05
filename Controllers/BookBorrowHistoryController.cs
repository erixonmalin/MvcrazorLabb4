using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcrazorLabb4.Data;
using MvcrazorLabb4.Models;

namespace MvcrazorLabb4.Controllers
{
    public class BookBorrowHistoryController : Controller
    {
        private readonly ApplicationDbContext db;

        public BookBorrowHistoryController(ApplicationDbContext _db)
        {
            db = _db;
        }

        // GET: BorrowHistories/Create
        public ActionResult Create(int? bookId)
        {
            if (bookId == null)
            {
                return BadRequest();
            }

            var book = db.Books.Find(bookId);
            if (book == null)
            {
                return NotFound();
            }

            ViewBag.CustomerId = new SelectList(db.Customers, "CustomerId", "FullName");
            ViewBag.BookId = new SelectList(db.Books, "BookId", "BookName");

            var newBorrow = new BorrowBookViewModel();
           
            return View(newBorrow);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(BorrowBookViewModel borrowBookViewModel)
        {
            int bookId = borrowBookViewModel.BookId;
            var bookHistory = await db.Books.FirstOrDefaultAsync(x => x.BookId == bookId);

            if (ModelState.IsValid)
            {
                if (bookHistory.IsBorrowed == false)
                {
                    var today = DateTime.Now.Date;

                    var newBorrow = new BookBorrowHistory
                    {
                        CustomerId = borrowBookViewModel.CustomerId,
                        BookId = borrowBookViewModel.BookId,
                        BorrowDate = DateTime.Now.Date,
                        ReturnDate = today.AddDays(14),
                    };
                    await db.BookBorrowHistories.AddAsync(newBorrow);
                    await db.SaveChangesAsync();
                    bookHistory.IsBorrowed = true;
                    db.Books.Update(bookHistory);
                    await db.SaveChangesAsync();

                    return RedirectToAction("Index", "Book");
                }
            }

            return RedirectToAction("Index", "Book");
        }


        // GET: BorrowHistories/Edit/5
        public async Task<ActionResult> Edit(int? bookId, DateTime? returnDate, int bbh)
        {
            if (bookId == null)
            {
                return BadRequest();
            }

            var returnBook = await db.BookBorrowHistories.FirstOrDefaultAsync(bh => bh.BookBorrowHistoryId == bbh);
            returnBook.ReturnDate = DateTime.Today;
            db.BookBorrowHistories.Update(returnBook);
            await db.SaveChangesAsync();

            var book = await db.Books.FirstOrDefaultAsync(b => b.BookId == bookId);
            book.IsBorrowed = false;
            db.Books.Update(book);
            await db.SaveChangesAsync();

            return RedirectToAction("Index", "Book");
        }

        // POST: BorrowHistories/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind("BorrowHistoryId,BookId,CustomerId,BorrowDate,ReturnDate")] BookBorrowHistory borrowHistory)
        {
            // Assuming the data is always valid
            var borrowHistoryItem = db.BookBorrowHistories.Include(i => i.BookId)
                .FirstOrDefault(i => i.BookBorrowHistoryId == borrowHistory.BookBorrowHistoryId);
            if (borrowHistoryItem == null)
            {
                return BadRequest();
            }

            borrowHistoryItem.ReturnDate = DateTime.Now;
            db.SaveChanges();
            return RedirectToAction("Index", "Book");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
