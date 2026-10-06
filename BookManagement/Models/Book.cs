using System.ComponentModel.DataAnnotations;

namespace BookManagement.Models
{
    public class Book
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Tên sách không được để trống")]
        public string Title { get; set; } = string.Empty;

        [Range(0.01, 100000000, ErrorMessage = "Giá phải lớn hơn 0")]
        public decimal Price { get; set; }
    }
}