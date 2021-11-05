SELECT p.id, p.NAME, p.description, p.price, po.option_name, po.option_type, o.name, o.price_increment
FROM products p
INNER JOIN product_options po on po.product_id = p.id
INNER JOIN options o on o.product_option_id = po.id
INNER JOIN stores s on s.id = p.store_id
WHERE s.shortcode = 'zatar-samar'
AND p.id = 1;

select * from product_options

select * from options