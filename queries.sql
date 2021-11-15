SELECT p.Id, p.Name, p.Description, p.Price, po.OptionName, po.OptionType, o.name, o.PriceIncrement
FROM Products p
INNER JOIN ProductOptions po on po.ProductId = p.id
INNER JOIN Options o on o.ProductOptionId = po.id
INNER JOIN stores s on s.id = p.StoreId
WHERE s.shortcode = 'zatar-samar'
AND p.id = 1;

select * from product_options

select * from options