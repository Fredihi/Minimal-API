using Microsoft.AspNetCore.Mvc;
using Minimal_API.Models.DTOs;
using Newtonsoft.Json;
using Web_Book.Models;
using Web_Book.Services;

namespace Web_Book.Controllers
{
	public class BookController : Controller
	{
		private readonly IBookService bookService;
        public BookController(IBookService bookservice)
        {
			bookService = bookservice;
        }

        public async Task<IActionResult> BookIndex()
		{
			List<BookDTO> list = new List<BookDTO>();
			var response = await bookService.GetAll<ResponseDTO>();
			if (response != null && response.IsSuccess)
			{
				list = JsonConvert.DeserializeObject<List<BookDTO>>(Convert.ToString(response.Result));
			}
			return View(list);
		}

		public async Task<IActionResult> BookDetails(int id)
		{
			var response = await bookService.GetById<ResponseDTO>(id);
			if (response != null && response.IsSuccess)
			{
				BookDTO model = JsonConvert.DeserializeObject<BookDTO>(Convert.ToString(response.Result));
				return View(model);
			}
			return NotFound();
		}

		public async Task<IActionResult> BookUpdate(int id)
		{
			var response = await bookService.GetById<ResponseDTO>(id);
			if (response != null && response.IsSuccess)
			{
				BookDTO model = JsonConvert.DeserializeObject<BookDTO>(Convert.ToString(response.Result));
				return View(model);
			}
			return NotFound();
		}

		[HttpPost]
		public async Task<IActionResult> BookUpdate(BookDTO model)
		{
			if (ModelState.IsValid)
			{
				var response = await bookService.UpdateBookAsync<ResponseDTO>(model);
				if (response != null && response.IsSuccess)
				{
					return RedirectToAction(nameof(BookIndex));
				}
			}
			return View(model);
		}
		
		public async Task<IActionResult> BookAdd()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> BookAdd(BookDTO model)
		{
			if (ModelState.IsValid)
			{
				var response = await bookService.AddBookAsync<ResponseDTO>(model);
				if (response != null && response.IsSuccess)
				{
					return RedirectToAction(nameof(BookIndex));
				}
			}
			return View(model);
		}

		public async Task<IActionResult> BookDelete(int id)
		{
			var response = await bookService.GetById<ResponseDTO>(id);
			if (response != null && response.IsSuccess)
			{
				BookDTO model = JsonConvert.DeserializeObject<BookDTO>(Convert.ToString(response.Result));
				return View(model);
			}
			return NotFound();
		}

		[HttpPost]
		public async Task<IActionResult> BookDelete(BookDTO model)
		{
			if (ModelState.IsValid)
			{
				var response = await bookService.DeleteBookAsync<ResponseDTO>(model.ID);
				if (response != null && response.IsSuccess)
				{
					return RedirectToAction(nameof(BookIndex));
				}
			}
			return NotFound();
		}
	}
}
