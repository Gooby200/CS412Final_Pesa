using CS412Final_Pesa.BLL;
using CS412Final_Pesa.BLL.Interfaces;
using CS412Final_Pesa.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CS412Final_Pesa.Controllers {
    [RoutePrefix("api/orders")]
    public class OrdersController : ApiController {
        private readonly IOrderBLL _orderBLL;

        public OrdersController() {
            _orderBLL = new OrderBLL();
        }

        [HttpGet]
        public List<Order> GetOrders() {
            return _orderBLL.GetOrders();
        }

        [HttpGet]
        [Route("{id}")]
        public HttpResponseMessage GetOrder(long id) {
            Order order = _orderBLL.GetOrder(id);
            if (order == null) {
                return Request.CreateResponse(HttpStatusCode.NotFound, "An order doesn't exist for that order id");
            }

            return Request.CreateResponse(HttpStatusCode.OK, order);
        }

        [HttpGet]
        [Route("customers/names/{partialName}")]
        public HttpResponseMessage GetCustomerNames(string partialName) {
            List<string> customerNames = new List<string>();
            List<Order> orders = _orderBLL.GetOrdersByCustomerName(partialName);
            if (orders != null)
                customerNames = orders.Select(x => x.CustomerName).Distinct().ToList();

            return Request.CreateResponse(HttpStatusCode.OK, customerNames);
        }

        [HttpGet]
        [Route("customers/{partialName}")]
        public HttpResponseMessage GetOrdersByCustomerName(string partialName) {
            List<Order> orders = _orderBLL.GetOrdersByCustomerName(partialName);
            return Request.CreateResponse(HttpStatusCode.OK, orders);
        }

        [HttpPost]
        [Route("addorder")]
        public HttpResponseMessage CreateOrder(OrderRequest orderRequest) {
            if (orderRequest.Order == null)
                return Request.CreateResponse(HttpStatusCode.BadRequest, "You must provide an order");

            if (orderRequest.ServiceIds == null)
                return Request.CreateResponse(HttpStatusCode.BadRequest, "You must provide a service list");

            Order order = _orderBLL.CreateOrder(orderRequest.Order, orderRequest.ServiceIds);

            return Request.CreateResponse(HttpStatusCode.OK, order);
        }

        [HttpPost]
        public HttpResponseMessage CreateOrder2(OrderRequest orderRequest) {
            if (orderRequest.Order == null)
                return Request.CreateResponse(HttpStatusCode.BadRequest, "You must provide an order");

            if (orderRequest.ServiceIds == null)
                return Request.CreateResponse(HttpStatusCode.BadRequest, "You must provide a service list");

            Order order = _orderBLL.CreateOrder(orderRequest.Order, orderRequest.ServiceIds);

            return Request.CreateResponse(HttpStatusCode.OK, order);
        }

        [HttpPut]
        public HttpResponseMessage ModifyOrder(OrderRequest orderRequest) {
            if (orderRequest.Order == null)
                return Request.CreateResponse(HttpStatusCode.BadRequest, "You must provide an order");

            Order order = _orderBLL.ModifyOrder(orderRequest.Order, orderRequest.ServiceIds);

            if (order == null)
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "There was an issue modifying your order");
            
            return Request.CreateResponse(HttpStatusCode.OK, order);
        }

        [HttpDelete]
        [Route("{id}")]
        public HttpResponseMessage DeleteOrder(long id) {
            Request.Headers.TryGetValues("APIKey", out var apiKey);
            if (apiKey == null || apiKey.FirstOrDefault() != "abcd")
                return Request.CreateResponse(HttpStatusCode.Forbidden, "Please provide the correct api key");

            Order order = _orderBLL.GetOrder(id);
            if (order == null)
                return Request.CreateResponse(HttpStatusCode.NotFound, "The order id provided does not exist");

            bool orderDeleted = _orderBLL.DeleteOrder(id);
            if (orderDeleted == false)
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "There was an issue deleting your order");

            return Request.CreateResponse(HttpStatusCode.OK, order);
        }
    }
}
