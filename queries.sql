SELECT * FROM stores
where shortcode = 'zatar-samar';

SELECT p.NAME, p.description  FROM products p
INNER JOIN stores s on s.id = p.store_id
WHERE s.shortcode = 'zatar-samar'